    MailMessage message = new MailMessage();
    message.From = new MailAddress("sender@sender.com");
     
    message.To.Add(new MailAddress("email@email.com"));
     
    message.Subject = "subject";
    message.Body = "content";
     
    SmtpClient client = new SmtpClient();
    client.Send(message);
