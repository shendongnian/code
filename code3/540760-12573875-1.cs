    public string VisitsNumber() 
        {
            string visits = string.Empty;
            string username = "youremailuser@domain.com";
            string pass = "yourpassword";
            string gkey = "?key=YourAPIkEYYourAPIkEYYourAPIkEYYourAPIkE";
        string dataFeedUrl = "https://www.google.com/analytics/feeds/data" + gkey;
        string accountFeedUrl = "https://www.googleapis.com/analytics/v2.4/management/accounts" + gkey;
        AnalyticsService service = new AnalyticsService("WebApp");
        service.setUserCredentials(username, pass);
        DataQuery query1 = new DataQuery(dataFeedUrl);
    
        query1.Ids = "ga:12345678";
        query1.Metrics = "ga:visits";
        query1.Sort = "ga:visits";
       
        //You were setting 2013-09-01 and thats an invalid date because it hasn't been reached yet, be sure you set valid dates
        //For start date is better to place an aprox date when you registered the domain on Google Analytics for example January 2nd 2012, for an end date the actual date is enough, no need to go further
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
        return visits;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            Response.Write("Visits:" + this.VisitsNumber());
        }
    }
