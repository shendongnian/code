    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    namespace Emailer
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void SendButton_Click(object sender, EventArgs e)
            {
                this.sendEmailBackgroundWorker.RunWorkerAsync(new _Email
                {
                    Recipient = this.recipientTextBox.Text,
                    Subject = this.subjectTextBox.Text,
                    Body = this.emailToSendTextBox.Text
                });
            }
    
            private class _Email
            {
                public string Body { get; set; }
                public string Subject { get; set; }
                public string Recipient { get; set; }
            }
    
            private void sendEmailBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                var email = (_Email)e.Argument;
    
                try
                {
                    Outlook.Application oApp = new Outlook.Application();
                    Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                    oMsg.Body = email.Body;
                    oMsg.Subject = email.Subject;
                    Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(email.Recipient);
                    oRecip.Resolve();
                    oMsg.Send();
                    oRecip = null;
                    oRecips = null;
                    oMsg = null;
                    oApp = null;
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
    
                e.Result = true;
            }
    
            private void sendEmailBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                string message;
    
                if (e.Result is Exception) 
                    message = "Error sending email: " + (e.Result as Exception).Message;
                else if (e.Result is bool && (bool)e.Result)
                    message = "Email is sent";
                else 
                    throw new Exception("Internal Error: not expecting " + e.Result.GetType().FullName);
    
                MessageBox.Show(message);
            }
        }
    }
