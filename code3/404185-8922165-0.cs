    bool resourceAvailable = false;
    
    WebClient webClient = new WebClient();
    try
    {
        bool pageContent = webClient.DownloadString("http://www.somePage.com");
        resourceAvailable = !String.IsNullOrEmpty(pageContent);
    }
    catch (WebException) { }
    // then you can perform actions depending of value of resourceAvailable flag (variable)
