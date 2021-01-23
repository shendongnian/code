    foreach (Attachment att in item.Attachments)
    {              
        if (att is FileAttachment)
        {
            FileAttachment fa = att as FileAttachment;
            // Do something with it
        }
    }
