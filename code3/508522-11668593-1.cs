    if(!string.IsNullOrEmpty(attachment))
    {
       System.Net.Mail.Attachment attachment;
       attachment = new System.Net.Mail.Attachment(strAttachment);
       mailMsg.Attachments.Add(attachment);
    }
