    email.Body = "[...]<img src=\"@@IMAGE@@\" alt=\"\">";
    
    // generate the contentID string using the datetime
    string contentID = Path.GetFileName(attachmentPath).Replace(".", "") + "@zofm";
    
    Attachment inline
    [...]
    email.Attachments.Add(inline);
    
    // replace the tag with the correct content ID
    email.Body = email.Body.Replace("@@IMAGE@@", "cid:" + contentID);
