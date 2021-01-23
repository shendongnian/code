    IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
    defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
    client = new WebClient
        {
            Proxy = defaultWebProxy
        };
    string downloadString = client.DownloadString(...);
