    static DriveService BuildUserAccountService(string userEmail)
    {
      UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
      new ClientSecrets
      {
         ClientId = "YOUR_CLIENT_ID", // your client Id
         ClientSecret = "YOUR_CLIENT_SECRET", // Your client secret
      },
      new[] { DriveService.Scope.Drive },
      userEmail,
      CancellationToken.None).Result;
    
      // Create the service.
      var service = new DriveService(new BaseClientService.Initializer()
      {
          HttpClientInitializer = credential,
          ApplicationName = "Drive API User Account Sample",
      });
    
      return service;
    }
