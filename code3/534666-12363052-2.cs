    public string GetJson()
    {
        // Create Client
        using (WebClient client = new WebClient())
        {
            // Assign Credentials
            client.Credentials = new NetworkCredential("username", "pass");
    
            // Grab Data
            return client.DownloadString(
                @"www.someurl.com"
            );
        }
    }
