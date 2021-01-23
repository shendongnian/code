    var message = new MailMessage();
    foreach (string path in attachmentPaths)
    {
        if (File.Exists(path))
        {
            message.Attachments.Add(new Attachment(path));
        }
    }
