    The other way to embed images in E-mail when using System.Net.Mail is 
    
    1.Attach image from local drive to email and assign a contentID to it and later use this contentID in the image URL. This can be done by : 
    
    C# :
    --------------------------
    msg.IsBodyHtml =true;
    Attachment inlineLogo = new Attachment(@"C:\Desktop\Image.jpg");
    msg.Attachments.Add(inlineLogo);
    string contentID = "Image";
    inlineLogo.ContentId = contentID;
    
    //To make the image display as inline and not as attachment
    
    inlineLogo.ContentDisposition.Inline = true;
    inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
    
    //To embed image in email
    
    msg.Body = "<htm><body> <img src=\"cid:" + contentID + "\"> </body></html>";
