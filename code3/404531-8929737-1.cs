    //Stream containing your CSV
    using (MemoryStream stream = new MemoryStream())
    {
      //Take the CSV string you have generated from your SQL data and write it to the stream  
      byte[] csvBytes = Encoding.ASCII.GetBytes(csv);
      stream.Write(csvBytes, 0, csvBytes.Length);
      //Add a new attachment to the E-mail message, using the correct MIME type
      mailObj.Attachments.Add(new Attachment(stream, new ContentType("text/csv")));
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
