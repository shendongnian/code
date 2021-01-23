    if (attachment.ContentType == ContentType.MessageRfc822)
    {
        string eml = ((MimeText)attachment).Text;
        IMail attachedMessage = new MailBuilder().CreateFromEml(eml);
        // process further
    }
