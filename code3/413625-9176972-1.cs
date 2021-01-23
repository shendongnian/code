    // Specify the file to be attached and sent.
    // This example assumes that a file named Data.xls exists in the
    // current working directory.
    string file = "data.xls";
    // Create a message and set up the recipients.
    MailMessage message = new MailMessage(
       "jane@contoso.com",
       "ben@contoso.com",
       "Quarterly data report.",
       "See the attached spreadsheet.");
    // Create  the file attachment for this e-mail message.
    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
    // Add time stamp information for the file.
    ContentDisposition disposition = data.ContentDisposition;
    disposition.CreationDate = System.IO.File.GetCreationTime(file);
    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
    // Add the file attachment to this e-mail message.
    message.Attachments.Add(data);
