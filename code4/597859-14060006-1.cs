    //create the mail message
    MailMessage mail = new MailMessage("orders@test.com", toAddress) { Subject = subject };
    //first we create the Plain Text part
    AlternateView plainView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", null, "text/plain");
    //then we create the Html part
    AlternateView htmlView = AlternateView.CreateAlternateViewFromString("<b>this is bold text, and viewable by those mail clients that support html</b>", null, "text/html");
    //add both views
    mail.AlternateViews.Add(plainView);
    mail.AlternateViews.Add(htmlView);
    //send the message as before
