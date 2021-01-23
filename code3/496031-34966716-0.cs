    public async Task PostAsync()
    {
        string json = "{\"add\": {\"doc\": {"
            + "\"id\":\"12345\","
            + "\"firstname\":\"Sam\","
            + "\"lastname\":\"Wills\","
            + "\"dob\":\"2016-12-14T00:00:00Z\""
            + "}}}";
    
        using (var client = new HttpClient())
        {
            string uri = "http://localhost:8983/solr/people/update/json?wt=json&commit=true";
            var jsonContent = new StringContent(json);
            await client.PostAsync(new Uri(uri), jsonContent);
        }
    }
