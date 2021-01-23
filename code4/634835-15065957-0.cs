    // Tweaked to match server version
    ExchangeService Service = new ExchangeService(ExchangeVersion.Exchange2007_SP1); 
    // Dummy but realistic credentials provided below
    Service.Credentials = new WebCredentials("john", "12345678", "MYDOMAIN");
    Service.AutodiscoverUrl("john.smith@mydomain.it");
    Folder inbox = Folder.Bind(Service, WellKnownFolderName.Inbox);
    Console.WriteLine("The folder name is " + inbox.DisplayName.ToString());
    //Console output follows (IT localized environment, 'Posta in arrivo' = 'Inbox')
    > The folder name is Posta in arrivo
