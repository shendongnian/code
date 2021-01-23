    if (attachment is FileAttachment)
    {
    	FileAttachment fileAttachment = attachment as FileAttachment;
    
    	// Load attachment contents into a file.
    	fileAttachment.Load(<file path>);
    }
    else // Attachment is an ItemAttachment (Email)
    {
    	ItemAttachment itemAttachment = attachment as ItemAttachment;
    
    	// Load Item with additionalProperties of MimeContent
    	itemAttachment.Load(EmailMessageSchema.MimeContent);
    
    	// MimeContent.Content will give you the byte[] for the ItemAttachment
    	// Now all you have to do is write the byte[] to a file
    	File.WriteAllBytes(<file path>, itemAttachment.Item.MimeContent.Content);
    }
