    using System;
    using System.Net;
    using System.Net.Mail;
     
    namespace GMailSample
    {
        class SimpleSmtpSend
        {
            static void Main(string[] args)
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);           
                client.EnableSsl = true;
                MailAddress from = new MailAddress("YourGmailUserName@gmail.com", "[ Your full name here]");           
                MailAddress to = new MailAddress("your recipient e-mail address", "Your recepient name");
                MailMessage message = new MailMessage(from, to);
                message.Body = "This is a test e-mail message sent using gmail as a relay server ";
                message.Subject = "Gmail test email with SSL and Credentials";
                NetworkCredential myCreds = new NetworkCredential("YourGmailUserName@gmail.com", "YourPassword", "");           
                client.Credentials = myCreds;
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception is:" + ex.ToString());
                }
                Console.WriteLine("Goodbye.");
            }
        }
    }
