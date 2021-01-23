    public string GetJson()
    {
        // Create Client
        using (WebClient client = new WebClient())
        {
            // Assign Credentials
            client.Credentials = new NetworkCredential("username", "pass");
    
            // Grab Data
            return client.DownloadString(
                @"https://www.tsubame.asia/pr/DataServices/service.ashx?logic=GetTsv&strDt=2012091109&endDt=2012091110&protocol=TCP&format=json"
            );
        }
    }
