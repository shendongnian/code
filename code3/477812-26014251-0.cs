    try
    {
        MimeMailMessage mail = new MailMessage("sender@yourdomain.com", receivingEmail, subject, body);
       string host = "smtpout.secureserver.net";
        int port = 465; // it's 465 if using SSL, otherwise 25 or 587
        MimeMailer smtpServer = new MimeMailer(host, port);
        smtpServer.Credentials = new NetworkCredential("sender@yourdomain.com", "yourpassword");
        smtpServer.EnableSsl = true;
        smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpServer.Send(mail);
    }
     catch (Exception ex)
    {
        // do something with the exception
        ...
    }
