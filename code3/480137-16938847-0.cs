    SendMail.CS Page
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Mail;
    
    namespace SendMailUsingWindowsForms
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                   
                    //Sending the email.
                    //Now we must create a new Smtp client to send our email.
    
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 25);   //smtp.gmail.com // For Gmail
                                                                                //smtp.live.com // Windows live / Hotmail
                                                                                //smtp.mail.yahoo.com // Yahoo
                                                                                //smtp.aim.com // AIM
                                                                                //my.inbox.com // Inbox
    
    
                    //Authentication.
                    //This is where the valid email account comes into play. You must have a valid email account(with password) to give our program a place to send the mail from.
    
                    NetworkCredential cred = new NetworkCredential("*******@gmail.com", "........");
    
                    //To send an email we must first create a new mailMessage(an email) to send.
                    MailMessage Msg = new MailMessage();
    
                    // Sender e-mail address.
                    Msg.From = new MailAddress(textBox1.Text);//Nothing But Above Credentials or your credentials (*******@gmail.com)
    
                    // Recipient e-mail address.
                    Msg.To.Add(textBox2.Text);
    
                    // Assign the subject of our message.
                    Msg.Subject = textBox3.Text;
    
                    // Create the content(body) of our message.
                    Msg.Body = textBox4.Text;
    
                    // Send our account login details to the client.
                    client.Credentials = cred;
    
                    //Enabling SSL(Secure Sockets Layer, encyription) is reqiured by most email providers to send mail
                    client.EnableSsl = true;
    
                    //Confirmation After Click the Button
                    label5.Text = "Mail Sended Succesfully";
    
                    // Send our email.
                    client.Send(Msg);
    
    
    
                }
                catch
                {
                    // If Mail Doesnt Send Error Mesage Will Be Displayed
                    label5.Text = "Error";
                }
            }
    
                   
        }
    }
