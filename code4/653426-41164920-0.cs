    StringBuilder Body = new StringBuilder();
    Body.Append("Your text");
    
    String FromEmail = "you email";
    String DisplayNameFromEmailMedico = "display when you receive email";
    MailMessage message = new MailMessage();
    message.From = new MailAddress(FromEmail, DisplayNameFromEmailMedico);
    message.To.Add(new MailAddress("myclient@gmail.com"));
    message.Subject = "subject that print in email";
    message.IsBodyHtml = true;
    message.Body = Body.ToString();
    SmtpClient client = new SmtpClient();
    
    NetworkCredential myCreds = new NetworkCredential("yoursmtpemail@gmail.com", "key from email smtp", "");
    client.EnableSsl = true;
    client.Credentials = myCreds;
    client.Send(message);
