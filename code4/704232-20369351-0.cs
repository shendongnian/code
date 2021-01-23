    using (WebClient webClient = new WebClient())
    {
    
        webClient.UseDefaultCredentials = true;
        webClient.Proxy = WebRequest.GetSystemWebProxy();
    }
