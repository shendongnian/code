    void SendEmail(string fromAddress, string toLine, string subject, string messageBody)
    {
      const string host = "smtp.server.com";
      const int port = 1234;
      const string userName = "(user)";
      const string password = "password";
      using (var smtpClient = new SmtpClient(host, port))
      {
        smtpClient.Credentials = new NetworkCredential(userName, password);
        var mailMessage = new MailMessage(fromAddress, toLine, subject, messageBody);
        smtpClient.Send(mailMessage);
      }
    }
