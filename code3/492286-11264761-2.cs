    foreach (var email in EmailsQueue)
    {
        MailMessage message = new MailMessage();
        try
        {
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
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            //error in sending email to one item in collection
            //Log it ig you want .Foreach will continue with remaining items    
        }
    }
