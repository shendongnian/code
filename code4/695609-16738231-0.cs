    using (MemoryStream memoryStream = new MemoryStream())
    {
        PdfWriter writertest = PdfWriter.GetInstance(doc, memoryStream);
        // Write contents of Pdf here
 
        // Set the position to the beginning of the stream.
        memoryStream.Seek(0, SeekOrigin.Begin);
    
        // Create attachment
        ContentType contentType = new ContentType();
        contentType.MediaType = MediaTypeNames.Application.Pdf;
        contentType.Name = fileNameTextBox.Text;
        Attachment attachment = new Attachment(memoryStream, contentType);
    
        // Add the attachment
        message.Attachments.Add(attachment);
    
        // Send Mail via SmtpClient
        smtpClient.Send(message);
    }
