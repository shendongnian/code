    using System;
    using System.Collections.Generic;
    using System.Text;
    using EASendMail; //add EASendMail namespace
    
    namespace mysendemail
    {
        class Program
        {
            static void Main(string[] args)
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                SmtpClient oSmtp = new SmtpClient();
            
                // Set sender email address, please change it to yours
                oMail.From = "test@emailarchitect.net";
    
                // Set recipient email address, please change it to yours
                oMail.To = "support@emailarchitect.net";
                
                // Set email subject
                oMail.Subject = "test html email with attachment";
    
                // Your SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.emailarchitect.net");
                
                // User and password for ESMTP authentication, if your server doesn't require
                // User authentication, please remove the following codes.            
                oServer.User = "test@emailarchitect.net";
                oServer.Password = "testpassword";
    
                // If your SMTP server requires SSL connection, please add this line
                // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
    
                try
                {
                   // Import html body and also import linked image as embedded images.
                   oMail.ImportHtml( "<html><body>test <img src=\"test.gif\"> importhtml</body></html>",
    	                "c:\\my picture", //test.gif is in c:\\my picture
    	                ImportHtmlBodyOptions.ImportLocalPictures | ImportHtmlBodyOptions.ImportCss );
    
                    Console.WriteLine("start to send email with embedded image...");
                    oSmtp.SendMail(oServer, oMail);
                    Console.WriteLine("email was sent successfully!");
                }
                catch (Exception ep)
                {
                    Console.WriteLine("failed to send email with the following error:");
                    Console.WriteLine(ep.Message);
                }
            }
        }
    }
 
