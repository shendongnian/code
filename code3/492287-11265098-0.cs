    var EmailsQueue = context.WC_EmailToolQueue.Where(t => t.EmailDate == null).ToList();
        foreach (var email in EmailsQueue)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(email.WC_EmailToolTemplates.SenderEmail);
            message.To.Add(new MailAddress(email.Email));
            message.Body = body;
            message.IsBodyHtml = true;
            message.Subject = subject;
            using (SmtpClient smtp = new SmtpClient
            {
                Host = email.WC_EmailToolTemplates.Host,
                Port = email.WC_EmailToolTemplates.Port,
                Credentials = new NetworkCredential(email.WC_EmailToolTemplates.SMTPUser, email.WC_EmailToolTemplates.SMTPPass),
                EnableSsl = email.WC_EmailToolTemplates.EnableSSL
            })
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    //log the error here <--------
                }
        }
