    // Attach
    mail.Attachment = new Attachment(memoryStream, contentType);
    mail.Attachment.NameEncoding = UTF8Encoding.UTF8;
    mail.Attachment.TransferEncoding = TransferEncoding.Base64;
    mail.Attachment.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
