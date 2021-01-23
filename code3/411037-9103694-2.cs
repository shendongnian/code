    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
    writer.Write("Hello its my sample file");
    writer.Flush();
    writer.Dispose();
    
    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
    attach.ContentDisposition.FileName = "myFile.txt";
    
    // I guess you know how to send email with an attachment
    // after sending email
    ms.Close();
