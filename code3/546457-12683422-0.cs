        $
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
        namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                MailAddress fromAddress = new MailAddress("YourEmailAcct@gmail.com", "NameForIt");
                MailAddress toAddress = new MailAddress("DesinationEmailAddress", "NameForDestination");
                const string fromPassword = "password";
                const string subject = "Subject";
                const string body = "First line of text \n Second line of text.";
        
                public Form1()
                {
                    InitializeComponent();
        
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
        
                    SmtpClient client = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
        
                    try
                    {
                        MailMessage message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        };
        
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error!" + ex.Message);
                    }
        
        
                }
                  
                }
            }
        
        
        
