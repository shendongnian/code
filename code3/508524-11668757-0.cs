    if (!string.IsNullOrWhiteSpace(strAttachment))
    {
        /*** Added mail attachment handling ***/    
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(strAttachment);
        mailMsg.Attachments.Add(attachment);
    }
