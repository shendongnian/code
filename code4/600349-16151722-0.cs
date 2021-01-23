    System.Net.Mime.ContentType calendarType = new System.Net.Mime.ContentType("text/calendar");
    AlternateView ICSview = AlternateView.CreateAlternateViewFromString(f.ToString(), calendarType);
    AlternateView HTMLV = AlternateView.CreateAlternateViewFromString(body, new System.Net.Mime.ContentType("text/html"));
    MailMessage email = new MailMessage("from@example.com", "to@example.com", "subject", "body");
    email.AlternateViews.Add(ICSview);
    email.AlternateViews.Add(HTMLV);
    SmtpClient client = new SmtpClient();
    client.Send(email);
