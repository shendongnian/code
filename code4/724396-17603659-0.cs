    var results = _ewsService.FindItems(WellKnownFolderName.Inbox, new ItemView(100)); //fetch 100 random emails from inbox
    foreach (var entry in results.Items)
    {
        if (entry is EmailMessage)
        {
            var temp = EmailMessage.Bind(_service, entry.Id);
            if (entry.HasAttachments)
            {
                temp.Load(new PropertySet(EmailMessageSchema.Attachments));
                foreach (var singleItem in temp.Attachments)
                {
                    if (singleItem is ItemAttachment)
                    {
                        var attachedMail = singleItem as ItemAttachment;
                        attachedMail.Load();
                        Console.WriteLine(attachedMail.Item is EmailMessage);
                        var workingMessage = attachedMail.Item as EmailMessage; //this should give you from, subject, body etc etc.
                    }
                }
            }
        }
    }
