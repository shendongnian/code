        string username = "youremailuser@domain.com";
        string pass = "yourpassword";
        string gkey = "?key=YourAPIkEY";
        
        string dataFeedUrl = "https://www.google.com/analytics/feeds/data" + gkey;
        string accountFeedUrl = "https://www.googleapis.com/analytics/v2.4/management/accounts" + gkey;
        
        AnalyticsService service = new AnalyticsService("WebApp");
        service.setUserCredentials(username, pass);
        
        DataQuery query1 = new DataQuery(dataFeedUrl);
   
        
        query1.Ids = "ga:12345678";
        query1.Metrics = "ga:visits";
        query1.Sort = "ga:visits";
    
        query1.GAStartDate = new DateTime(2012, 1, 2).ToString("yyyy-MM-dd"); 
        query1.GAEndDate = DateTime.Now.ToString("yyyy-MM-dd");
        query1.StartIndex = 1;        
    
        DataFeed dataFeedVisits = service.Query(query1);
    
        foreach (DataEntry entry in dataFeedVisits.Entries)
        {
            string st = entry.Title.Text;
            string ss = entry.Metrics[0].Value;
            visits = ss;
        }
