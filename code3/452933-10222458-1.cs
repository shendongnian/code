    Collection<string> MailAttachments = new Collection<string>();
    MailAttachments.Add("C:\\Sample.JPG");
    mailMessage = new MailMessage();
    foreach (string filePath in emailNotificationData.MailAttachments)
    {
        Attachment attachment = new Attachment(filePath);
        mailMessage.Attachments.Add(attachment);
    }
    SmtpClient smtpClient = new SmtpClient();
    smtpClient.Host = SmtpHost;
    smtpClient.Send(mailMessage);
