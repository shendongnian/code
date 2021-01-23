    // SMTP options
    string Host = "smtp.mail.emea.microsoftonline.com";
    Int16 Port = 587;
    bool SSL = true;
    string Username = "myname@mydomain.com";
    string Password = "mypassword";
        
    // Mail options
    string To = "reciever@recieverdomain.com";
    string From = "myname@mydomain.com";
    string Subject = "This is a test";
    string Body = "It works!";
        
    MailMessage mm = new MailMessage(From, To, Subject, Body);
    SmtpClient sc = new SmtpClient(Host, Port);
    NetworkCredential netCred = new NetworkCredential(Username, Password);
    sc.EnableSsl = SSL;
    sc.UseDefaultCredentials = false;
    sc.Credentials = netCred;
        
    try
    {
       Console.WriteLine("Sending e-mail message...");
      sc.Send(mm);
    }
    catch (Exception ex)
    {
       Console.WriteLine("Error: {0}", ex.ToString());
    }
