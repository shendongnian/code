    private dynamic GetLinkedInUser(string code)
    {
        dynamic jresult;
        NameValueCollection parameters = new NameValueCollection {
            {"client_id", *ClientId*},
            {"client_secret", *ClientSecret*},
            {"grant_type", "authorization_code"},
            {"redirect_uri", "https://" + Request.Host + "/Login/LoginLinkedIn"},
            {"code", code}
        };
        WebClient client = new WebClient();
        byte[] result = client.UploadValues("https://www.linkedin.com/oauth/v2/accessToken", "POST", parameters);
        string response = System.Text.Encoding.Default.GetString(result);
        string accessToken = JsonConvert.DeserializeObject<dynamic>(response).access_token;
        
        WebRequest webReq = WebRequest.Create("https://api.linkedin.com/v1/people/~:(id,email-address,first-name,last-name)?format=json");
        webReq.Method = "GET";
        webReq.Headers.Add("Authorization","Bearer "+accessToken);
        HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();
        using (StreamReader reader = new StreamReader(webResponse.GetResponseStream())) {
            string objText = reader.ReadToEnd();
            jresult = JsonConvert.DeserializeObject<dynamic>(objText);
        }
        return jresult;
    }
