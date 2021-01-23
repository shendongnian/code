    //create the mail message
    var mail = new MailMessage();
    
    //set the addresses
    mail.From = new MailAddress("me@mycompany.com");
    mail.To.Add("you@yourcompany.com");
    
    //set the content
    mail.Subject = "This is an email";
    
    //first we create the Plain Text part
    var plainView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", null, "text/plain");
    //then we create the Html part
    var htmlView = AlternateView.CreateAlternateViewFromString("<b>this is bold text, and viewable by those mail clients that support html</b>", null, "text/html");
    mail.AlternateViews.Add(plainView);
    mail.AlternateViews.Add(htmlView);
    
    //send the message
    var smtp = new SmtpClient("127.0.0.1"); //specify the mail server address
    smtp.Send(mail);
