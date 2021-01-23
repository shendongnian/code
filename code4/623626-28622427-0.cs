    EmailProperties properties = new EmailProperties();
    properties.To = new string[] { user.LoginName };
    properties.Subject = "Test subject";
    properties.Body = "Test body";
    ClientContext context = new ClientContext(webUrl);
