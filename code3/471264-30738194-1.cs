    //First you will need a DriveService:
    
    ClientSecrets cs = new ClientSecrets();
    cs.ClientId = yourClientId;
    cs.ClientSecret = yourClientSecret;
    
    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            cs,
                            new[] { DriveService.Scope.Drive },
                            "user",
                            CancellationToken.None,
                            null
                        ).Result;
    
    DriveService service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "TheAppName"
                    });
    
    //then you can upload the file:
    
    File body = new File();
    body.Title = "document title";
    body.Description = "document description";
    body.MimeType = "application/vnd.google-apps.folder";
    
    File folder = service.Files.Insert(body).Execute();
