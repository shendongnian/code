    public static void Send(string Subject, string From, string Body, List<emailAddress> CC, MailAddress To, bool BodyHTML)
    {
      try
      {
        MailMessage mail = new MailMessage();
        if (CC != null)
        {
          foreach (emailAddress ea in CC)
          {
            mail.CC.Add(new MailAddress(ea.email, ea.fullname));
          }
        }
        mail.Subject = Subject;
        mail.Body = Body;
        mail.IsBodyHtml = BodyHTML;
        mail.From = new MailAddress(From);
        mail.To.Add(To);
        
        SmtpClient client = new SmtpClient();
        client.Host = "mail.yourdomain.com";
        client.Send(mail);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
 
