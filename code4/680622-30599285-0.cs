    var certificate = new X509Certificate2("pathTo***.p12", "notasecret", X509KeyStorageFlags.Exportable);
            var serviceAccountEmail = "********-*********@developer.gserviceaccount.com";
            var userAccountEmail = "******@gmail.com";
            ServiceAccountCredential credential = new ServiceAccountCredential(
                       new ServiceAccountCredential.Initializer(serviceAccountEmail)
                       {
                           Scopes = new[] { DriveService.Scope.Drive },
                           User = userAccountEmail
                       }.FromCertificate(certificate));
            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "*****",
            });
