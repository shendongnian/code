    public static void SendMail(string Message, string Subject)
        {
            bool retVal;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
    
            MailAddress fromAddres = new MailAddress(FromMail, "Test");
            message.From = fromAddres;
            // To address collection of MailAddress
            message.To.Add(ToMail);
            message.Subject = Subject;
            smtpClient.Host = HotName;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPassword);
            message.IsBodyHtml = true;
            // Message body content
            message.Body = Message;    
            
            smtpClient.Send(message);
            retVal = true;
            message.Dispose();
        }
