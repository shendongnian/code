    private string getAppAccessToken()
    {
        string facebookAppId = ConfigurationProvider.GetSetting("FacebookAppId");
        string facebookAppSecret = ConfigurationProvider.GetSetting("FacebookAppSecret");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
            String.Format("https://graph.facebook.com/oauth/access_token?grant_type=client_credentials&client_id={0}&client_secret={1}",
            facebookAppId, facebookAppSecret));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        var responseStream = new StreamReader(response.GetResponseStream());
        var responseString = responseStream.ReadToEnd();
        if (responseString.Contains("access_token="))
        {
            return responseString.Replace("access_token=", string.Empty);
        }
        return "";
    }
    private void postRequest(string id, string message)
    {
        FacebookClient app = new FacebookClient(this.getAppAccessToken());
        dynamic parameters = new ExpandoObject();
        parameters.message = message;
        parameters.title = "Please use our app";
        dynamic myId = app.Post(id + "/apprequests", parameters);
    }
