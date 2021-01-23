    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
    contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
    contentType.Name = "test.docx";
    msg.Attachments.Add(new Attachment("I:/files/test.docx"), contentType);
    ...
