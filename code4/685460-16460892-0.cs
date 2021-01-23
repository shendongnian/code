    using System;
    using System.Net.Mail;
     
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
     
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.customsmtp.com");
     
                    mail.From = new MailAddress("fromEmail@fromemail.com");
                    mail.To.Add("toemail@toemail.com");
                    mail.Subject = "Your Subject";
                    mail.Body = "Your Textbox Here!";
                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Seems some problem!");
                }
     
                Console.WriteLine("Email sent successfully!");
                Console.ReadLine();
            }
     
        }
