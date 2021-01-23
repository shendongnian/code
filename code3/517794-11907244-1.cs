    //... other System.Net.Mail.MailMessage creation code
    // CustomerSignature is a byte array containing the image
    System.IO.MemoryStream ms = new System.IO.MemoryStream(CustomerSignature);
    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
    contentType.MediaType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
    contentType.Name = "signature.jpg";
    System.Net.Mail.Attachment imageAttachment = new System.Net.Mail.Attachment(ms, contentType);
    mailMessage.Attachments.Add(imageAttachment);
    System.Net.Mail.LinkedResource signature = new System.Net.Mail.LinkedResource(ms, "image/jpeg");
    signature.ContentId = "CustomerSignature";
    System.Net.Mail.AlternateView aView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mailMessage.Body, new System.Net.Mime.ContentType("text/html"));
    aView.LinkedResources.Add(signature);
    mailMessage.AlternateViews.Add(aView);
