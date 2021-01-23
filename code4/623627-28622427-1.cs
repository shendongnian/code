    user.LoginName after EnusreUser for Ex:
    User user = clientContext.Web.EnsureUser(strlogonName);
    clientContext.Load(user);
    clientContext.ExecuteQuery();
    EmailProperties properties = new EmailProperties();
    properties.To = new string[] { user.LoginName };
    properties.Subject = "Test subject";
    properties.Body = "Test body";
    ClientContext context = new ClientContext(webUrl);
    Utility.SendEmail(context, properties);
