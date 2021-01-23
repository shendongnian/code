    var messageCopy = message;
    new Thread(a =>
            MailHelper.SendMessage(
                new ListDictionary { { "$Url$", messageCopy .Url } },
                messageCopy.Mail.Headers.From.Address, 
                "EmailConvertSuccess.txt",
                a as MailAttachment)
        ).Start(attachment);
