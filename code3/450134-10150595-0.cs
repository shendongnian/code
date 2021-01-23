    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("yourEmailId", "destinationEmailId");
    mail.Subject = ""; //Enter the text for the subject of the mail in quotes.
    mail.Body = ""; //Enter the text for the body of mail within the quotes.
    mail.IsBodyHtml = true;
    SmtpClient client = new SmtpClient("smtp.live.com");
    NetworkCredential cred = new NetworkCredential("yourEmailId", "yourPassword");
    client.EnableSsl = true;
    client.Credentials = cred;
    try
    {
    client.Send(mail);
    }
    catch (Exception)
    {
    }
