    MailMessage m = new MailMessage();
                    
    m.From = new MailAddress("Smith@MyDomain.com");
    m.To.Add(new MailAddress("someone@TheirCompany.com));
    m.Subject = "Message from Smith";
    m.Body = "Hello, Test Message";
    SendEmail(m);
    var smtp = new SmtpClient
    {
    Host = "localhost",
    Port = 25,
    UseDefaultCredentials = false,                    
    };
    
    smtp.Send(m);
