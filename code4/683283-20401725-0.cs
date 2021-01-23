    IMail email = new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid));
    ReadOnlyCollection<MimeData> attachments = mail.ExtractAttachmentsFromInnerMessages();
    foreach (MimeData mime in attachments)
    {
         mime.Save(@"c:\" + mime.SafeFileName);
    }
