     using System.Net.Mail; //goes on top
     //goes in your class
     public void sendEmail(string emailMessage, 
         string emailSubject, 
         string emailAddress, string from, 
         string fromAddress, string emailCC, 
         string emailBCC)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(fromAddress, from);
                msg.To.Add(emailAddress);
                if (emailCC != null && emailCC.ToString().Length > 1)
                    msg.CC.Add(emailCC);
                if (emailBCC != null && emailBCC.ToString().Length > 1)
                    msg.Bcc.Add(emailBCC);
                msg.Priority = MailPriority.High;
                msg.Subject = emailSubject;
                msg.Body = emailMessage;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = info.SMTPServer;
                client.Port = 25;
                client.EnableSsl = true;
                // client.UseDefaultCredentials = some System.Net.NetworkCredential var;
                client.Credentials = info.networkCredentials;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                // Use SendAsync to send the message asynchronously
                client.Send(msg);
            }
            catch
            {
                //handle exception
            }
        }
