    bool resourceAvailable = false;
    
    WebClient webClient = new WebClient();
    try
    {
        string pageContent = webClient.DownloadString("http://www.someResource.com");
        resourceAvailable = !String.IsNullOrEmpty(pageContent);
    }
    catch (WebException) { }
    // then you can perform actions depending on value of resourceAvailable flag (variable)
