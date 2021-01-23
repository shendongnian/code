    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.Mail;
    using System.Net;
    
    namespace GmailSendTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MailAddress fromAddress = new MailAddress("myusername@gmail.com");
                MailAddress toAddress = new MailAddress("myusername@gmail.com");
    
                MailMessage mail = new MailMessage(fromAddress.Address, toAddress.Address);
                mail.Subject = "Testing";
                mail.Body = "contents.";
    
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("myusername", "mypassword"); 
    
                try
                {
                    client.Send(mail);
                    MessageBox.Show("Mail Sent!", "Success", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }
    }
