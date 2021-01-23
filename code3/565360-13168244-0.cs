    const string HTML_TAG_PATTERN = "<.*?>";
    static string StripHTML(string inputString)
    {
      return Regex.Replace(inputString, HTML_TAG_PATTERN, string.Empty);
    }
    public static void sendMessage()
    {
      var username = "john.doe@gmail.com";
      var password = "password";
      MailAddress MailFrom = new MailAddress("john.doe@gmail.com");
      MailAddress MailTo = new MailAddress("john.doe@gmail.com");
      var subject = "TEST SUBJECT";
      var attachmentPath = "test.pdf";
      var mailBody = "<b>test</b>";
      NetworkCredential cred = new NetworkCredential(username, password);
      System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
      smtp.Host = "smtp.gmail.com";
      smtp.UseDefaultCredentials = false;
      smtp.EnableSsl = true;
      smtp.Credentials = cred;
      smtp.Port = 587;
      MailMessage mail = new MailMessage();
      mail.IsBodyHtml = true;
      AlternateView avAlternateView = null;
      Encoding myEncoding = Encoding.GetEncoding("UTF-8");
      avAlternateView = AlternateView.CreateAlternateViewFromString(StripHTML(mailBody), myEncoding, "text/plain");
      mail.AlternateViews.Add(avAlternateView);
      avAlternateView = AlternateView.CreateAlternateViewFromString(mailBody, myEncoding, "text/html");
      mail.AlternateViews.Add(avAlternateView);
      mail.Sender = MailFrom;
      mail.From = MailFrom;
      mail.ReplyTo = MailFrom;
      mail.To.Add(MailTo);
      mail.Subject = subject;
      mail.SubjectEncoding = Encoding.GetEncoding("UTF-8"); 
      
      mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
      Attachment attachment = new Attachment(attachmentPath);
      mail.Attachments.Add(attachment);
      try
      {
        smtp.Send(mail);
      }
      catch (Exception ex)
      {
      }
    }
