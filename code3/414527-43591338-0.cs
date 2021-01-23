    string smtpAddress = "smtp.gmail.com";
    int portNumber = 587;
    bool enableSSL = true;
    string emailFrom = "companyemail";
    string password = "password";
    string emailTo = "Your email";
    string subject = "Hello!";
    string body = "Hello, Mr.";
    MailMessage mail = new MailMessage();
    mail.From = new MailAddress(emailFrom);
    mail.To.Add(emailTo);
    mail.Subject = subject;
    mail.Body = body;
    mail.IsBodyHtml = true;
    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
    {
       smtp.Credentials = new NetworkCredential(emailFrom, password);
       smtp.EnableSsl = enableSSL;
       smtp.Send(mail);
    }
