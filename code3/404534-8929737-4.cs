    //Stream containing your CSV (convert it into bytes, using the encoding of your choice)
    using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(csv)))
    {
      //Add a new attachment to the E-mail message, using the correct MIME type
      Attachment attachment = new Attachment(stream, new ContentType("text/csv"));
      attachment.Name = "test.csv";
      mailObj.Attachments.Add(attachment);
      //Send your message
      try
      {
        using(SmtpClient client = new SmtpClient([host]){Credentials = [credentials]})
        {
          client.Send(mailObj);
        }
      }
      catch
      {
        return "{\"Error\":\"Not Sent\"}";
      }
    }
