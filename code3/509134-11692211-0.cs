    bool work;
    
    public void getMethod(string parameters)
    {
        var webClient = new WebClient();
        webClient.OpenReadCompleted += webClient_OpenReadCompleted;
        string uri = apiUri + parameters + "&access_token=" + access_token;
        webClient.OpenReadAsync(new Uri(uri));
        work = true;
        while(work) { Thread.Sleep(100); }
    }
     
    void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        XDocument xml = XDocument.Load(e.Result);
        response = xml.ToString();
        work = false;
    }
