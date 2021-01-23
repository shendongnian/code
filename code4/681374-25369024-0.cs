    //Create WebRequest
    Uri JsonUri = new Uri(new Uri(JIRAInstanceUri), ServiceUri);
    WebRequest RestWebRequest = WebRequest.Create(JsonUri);
    RestWebRequest.Method = "GET";
    RestWebRequest.ContentType = "application/json";
    //Add proxy to WebRequest
    ProxyServer.BypassArrayList.Add(JsonUri);
    RestWebRequest.Proxy = ProxyServer;
    //Setup authorization
    string Base64Credentials = GetEncodedCredentials(UserName, Password);
    RestWebRequest.Headers["Authorization"] = "Basic " + Base64Credentials;
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
