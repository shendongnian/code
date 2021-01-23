    String serviceAccountEmail = "xxxxxxx@developer.gserviceaccount.com";
    var certificate = new X509Certificate2(@"xxxxx.p12", "notasecret", X509KeyStorageFlags.Exportable);
    ServiceAccountCredential credential = new ServiceAccountCredential(
    new ServiceAccountCredential.Initializer(serviceAccountEmail)
    {
    Scopes = new[] { DirectoryService.Scope.AdminDirectoryUser},
    User = "your USER",  
    }.FromCertificate(certificate));
    var service = new DirectoryService(new BaseClientService.Initializer()
    {
    HttpClientInitializer = credential,
    ApplicationName = "name of your app",
    });
    var listReq = service.Users.List();
    listReq.Domain = "your domain";
    Users allUsers = listReq.Execute();
    foreach(User myUser in allUsers.UsersValue){
        Console.WriteLine("*" + myUser.PrimaryEmail);
    }
    Console.ReadKey();
