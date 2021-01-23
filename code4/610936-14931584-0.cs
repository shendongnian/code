    ServicePointManager.ServerCertificateValidationCallback = this.CertificateValidationCallBack;
    ExchangeService exchangeWebService = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
    
    exchangeWebService.Credentials = new WebCredentials("username@domain.local", "myPassword");
    exchangeWebService.AutodiscoverUrl("username@domain.com", this.RedirectionUrlValidationCallback);
    
    CalendarFolder calendarFolder = CalendarFolder.Bind(exchangeWebService, new FolderId(WellKnownFolderName.Calendar, "username@domain.com"));
