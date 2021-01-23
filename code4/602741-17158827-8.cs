    private const string SERVICE_ACCOUNT_EMAIL = "YOUR_SERVICE_ACCOUNT_EMAIL_HERE"; //looks like XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX@developer.gserviceaccount.com;
    
    static DriveService BuildServiceAccountService()
    {
      var certificate = new X509Certificate2(PATH_TO_YOUR_X509_CERT,
          "notasecret", X509KeyStorageFlags.Exportable);
      var credential = new ServiceAccountCredential(
          new ServiceAccountCredential.Initializer(SERVICE_ACCOUNT_EMAIL)
          {
              Scopes = new[] { DriveService.Scope.Drive },
              User = "ACTUAL_EMAIL_ADDRESS" // this should be the normal xxxxxx@gmail account that has the google drive files
          }.FromCertificate(certificate));
    
      // Create the service.
      var service = new DriveService(new BaseClientService.Initializer()
      {
          HttpClientInitializer = credential,
          ApplicationName = "Drive API Service Account Sample",
      });
    
      return service;
    }
    
    public static void DownloadSpreadsheetAsXlsx(string spreadsheetName, string filePath)
    {
      var service = BuildServiceAccountService();
      var request = service.Files.List();
      request.Q = String.Format("title = '{0}'", spreadsheetName);
      var files = request.Execute();
      var file = files.Items.FirstOrDefault();
    
      var dlUrl = String.Format("https://docs.google.com/spreadsheets/d/{0}/export?format=xlsx&id={0}", file.Id);
    
      File.WriteAllBytes(filePath, service.HttpClient.GetByteArrayAsync(dlUrl).Result);
    }
