    string keyFilePath = Server.MapPath("~/App_Data/Your-API-Key-Filename.json");
    string json = System.IO.File.ReadAllText(keyFilePath);
     
    var cr = JsonConvert.DeserializeObject(json);
    
    var xCred = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(cr.client_email)
    {
        Scopes = new[] {
            AnalyticsReportingService.Scope.Analytics
        }
    }.FromPrivateKey(cr.private_key));
                    
    using (var svc = new AnalyticsReportingService(
        new BaseClientService.Initializer
        {
            HttpClientInitializer = xCred,
            ApplicationName = "[Your Application Name]"
        })
    )
    {
        // Create the DateRange object.
        DateRange dateRange = new DateRange() { StartDate = "2017-05-01", EndDate = "2017-05-31" };
     
        // Create the Metrics object.
        Metric sessions = new Metric { Expression = "ga:sessions", Alias = "Sessions" };
     
        //Create the Dimensions object.
        Dimension browser = new Dimension { Name = "ga:browser" };
     
        // Create the ReportRequest object.
        ReportRequest reportRequest = new ReportRequest
        {
            ViewId = "[A ViewId in your account]",
            DateRanges = new List() { dateRange },
            Dimensions = new List() { browser },
            Metrics = new List() { sessions }
        };
     
        List requests = new List();
        requests.Add(reportRequest);
     
        // Create the GetReportsRequest object.
        GetReportsRequest getReport = new GetReportsRequest() { ReportRequests = requests };
     
        // Call the batchGet method.
        GetReportsResponse response = svc.Reports.BatchGet(getReport).Execute();
    }
