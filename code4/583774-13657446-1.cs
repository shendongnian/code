    using System;
    using System.Net.Mail;
    using System.Collections.Generic;
    using System.Text;
    using Gtk;
    using GtkSharp;
    using GLib;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    
    namespace KentSoft
        {
        class  printTest : Window
        {
        public  printTest() : base("Kent_Calisma")
        {
        try{
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("yourmailadress@gmail.com");
        mail.To.Add("destinationmailadress@gmail.com");
        mail.Subject = "TEST";
        mail.Body = "This is for testing SMTP mail from GMAIL";
        SmtpServer.Port = 587;
    
        SmtpServer.Credentials = new System.Net.NetworkCredential("gmailusername without @gmail.com", "gmailpassword");
    
        SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
    
        SmtpServer.Send(mail);
    
    }
    
    catch(Exception e){
        Console.WriteLine("Ouch!"+e.ToString());
      }
    }
    
    public static void Main()
        {
       Application.Init();
       new printTest();
       Application.Run();
              }
            }
          }
