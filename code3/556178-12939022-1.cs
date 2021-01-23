    using(var message = new MailMessage(from, to))
    {
       foreach (UploadedDocument doc in docs)
       {
           stream = new MemoryStream(doc.doc);
           attach = new Attachment(stream, "Attachment-" + counter.ToString());
           message.Attachments.Add(attach);              
       }
    
       emailClient.Send(message);
    }
