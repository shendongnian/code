    WebClient webClient = new WebClient();
            
    NameValueCollection values = new NameValueCollection();
    values.Add("FirstName", "John");
    values.Add("LastName", "Smith");
    values.Add("Age", "46");
    webClient.UploadValues("http://example.com/", values);
