    public void GetImages()   
    {   
        string uri = "/mini_logos/" + path;   
        WebClient m_webClient = new WebClient();   
        imageUri = new Uri(uri, UriKind.Relative);   
       
        m_webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_ImageOpenReadCompleted);   
        m_webClient.OpenReadAsync(imageUri);   
    } 
