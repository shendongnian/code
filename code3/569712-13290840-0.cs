    using (SmtpClient client = GetSmtpClient(settings)) {
      using (MailMessage message = new MailMessage()) {
        message.To.Add(toList);
        message.Subject = subject;
        message.Body = textTemplate;          
        message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(htmlTemplate, new ContentType("text/html")));
        client.Send(message);
      }
    }
