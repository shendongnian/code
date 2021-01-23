    Guid contentId = Guid.NewGuid().ToString();
    
    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
      "This is a image:<br /><img src=\"cid:" + contentId + "\" />", 
      null, "text/html");
    
    ContentType ct = new ContentType(MediaTypeNames.Image.Jpeg);
    
    LinkedResource embedded = new LinkedResource("c:\\image1.jpg", ct);
    embedded.ContentId = contentId;
    htmlView.LinkedResources.Add(embedded);
    
    mail.AlternateViews.Add(altView);
    SmtpClient client = new SmtpClient();
    client.Send(mail);
