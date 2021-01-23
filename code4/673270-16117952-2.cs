    using system.net
    MailMessage MyMailMessage = new MailMessage();
    MyMailMessage.From = new MailAddress("emailid");
    MyMailMessage.To.Add("To");
    MyMailMessage.Subject = "Feedback Form";
    MyMailMessage.Body = "This is the test message";
    MyMailMessage.IsBodyHtml = true;
    SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");
    SMTPServer.Port = 587;
    SMTPServer.Credentials = new System.Net.NetworkCredential("Username","password");
    SMTPServer.EnableSsl = true;
    try
    {
        SMTPServer.Send(MyMailMessage);
    }
    catch (Exception ex)
    {
        ex.message("error");
    }
