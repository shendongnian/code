    IWebProxy proxy = new WebProxy("proxy address", port number); 
    proxy.Credentials = new NetworkCredential("username", "password");
    
    using (var webClient = new System.Net.WebClient())
    {
        webClient.Proxy = proxy;
                
        webClient.DownloadString("url");
                                
    }
