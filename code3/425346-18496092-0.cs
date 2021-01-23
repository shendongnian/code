    public static string Login()
    {
        string responseJsonString = string.Empty;
        StringBuilder str = new StringBuilder();
        str.AppendFormat("{0}?grant_type=password&client_id={1}&client_secret={2}&username={3}&password={4}"
                         , LoginOAuthUrl, ClientID, ClientSecret, ClientUserName, ClientPassword);
        // Request token
        try
        {
            HttpWebRequest request = WebRequest.Create(str.ToString()) as HttpWebRequest;
    
            if (request != null)
            {
                request.Method = "POST";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Get the "access_token" and "instance_url" from the response.
                        // Convert the JSON response into a token object
                        
    
                        // Here we get the response as a stream.
                        using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                        {
                            responseJsonString = responseStream.ReadToEnd();
                            // Deserialize JSON response into an Object.
                            JsonValue value = JsonValue.Parse(responseJsonString);
                            JsonObject responseObject = value as JsonObject;
                            AccessToken = (string)responseObject["access_token"];
                            InstanceUrl = (string)responseObject["instance_url"];
                            return "We have an access token: " + AccessToken + "\n" + "Using instance " + InstanceUrl + "\n\n";
                        }
                    }
                }
            }
            return responseJsonString;
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format("Unable to login to salesforce: {0}", str), ex);
        }
    }
    
    public static string Query()
    {            
        string RequestUrl = InstanceUrl + "/services/data/v28.0/query";
        string queryParam = "q=" + QUERY;
        // Read the REST resources
        string responseJsonString = HttpGet(RequestUrl, queryParam);
        return responseJsonString;
    }
    
    public static string HttpGet(string URI, string Parameters)
    {
        // Add parameters to the URI
        string requestUri = URI + "?" + Parameters;
        System.Net.WebRequest req = System.Net.WebRequest.Create(requestUri);
        req.Method = "GET";
        req.Headers.Add("Authorization: OAuth " + AccessToken);
    
        // Do the GET request
        System.Net.WebResponse resp = req.GetResponse();
        if (resp == null) return null;
        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        return sr.ReadToEnd().Trim();
    }
