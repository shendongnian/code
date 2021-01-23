    var attachment = new Attachment(strAttachment);
    // Add time stamp information for the file.
    ContentDisposition disposition = attachment.ContentDisposition;
    disposition.CreationDate = System.IO.File.GetCreationTime(strAttachment);
    disposition.ModificationDate = System.IO.File.GetLastWriteTime(strAttachment);
    disposition.ReadDate = System.IO.File.GetLastAccessTime(strAttachment);
    mailMsg.Attachments.Add(attachment);
