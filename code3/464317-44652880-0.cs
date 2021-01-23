    private static SheetsService AuthorizeGoogleApp()
     {
         UserCredential credential;
    
         using (var stream =
             new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
         {
             string credPath = System.Environment.GetFolderPath(
                 System.Environment.SpecialFolder.Personal);
             credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");
    
             credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                 GoogleClientSecrets.Load(stream).Secrets,
                 Scopes,
                 "user",
                 CancellationToken.None,
                 new FileDataStore(credPath, true)).Result;
             Console.WriteLine("Credential file saved to: " + credPath);
         }
    
         // Create Google Sheets API service.
         var service = new SheetsService(new BaseClientService.Initializer()
         {
             HttpClientInitializer = credential,
             ApplicationName = ApplicationName,
         });
    
         return service;
     }
