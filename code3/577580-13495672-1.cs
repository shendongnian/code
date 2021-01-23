            string subject = "my subject";
            string body = "my html body";
            int port = 587;
            string SMTPhost = "smtp.gmail.com";
            string sender = "my@email.com";
            System.Net.Mail.MailPriority mPriority = System.Net.Mail.MailPriority.Low;        
            List<string> recipients = new List<string>(){"some@reciever.com"};
            bool enableSSL = true;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("UserName","Password");
            SendMailWithAuthentication(recipients, sender, subject, body, true,
                SMTPhost,
                mPriority, credentials,
                enableSSL);
