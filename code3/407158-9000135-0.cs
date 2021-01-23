    var client = new RestClient();
    client.BaseUrl = url;
    // client.Authenticator = new HttpBasicAuthenticator("username", "password");
    
    var request = new RestRequest();
    request.Resource = requestXML; // e.g. C:\Temp.xml
    
    RestResponse response = client.Execute(request);
