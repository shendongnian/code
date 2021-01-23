    /// <summary>
    /// Make a YQL query and return an unformated xml string
    /// </summary>
    /// <param name="key">Application Consumer Key</param>
    /// <param name="secret">Application Consumer Secret</param>
    /// <param name="query">The YQL query you want to run</param>
    /// <returns>Returns formatted xml in the form of a string from YQL</returns>
    protected string yqlQuery(string key, string secret, string query)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"http://query.yahooapis.com/v1/yql?q=" + query);
        OAuthBase YQL = new OAuthBase();
        string nonce = YQL.GenerateNonce();
        string timestamp = YQL.GenerateTimeStamp();
        request.Headers.Add(
            "Authorization: OAuth " +
            "realm=\"yahooapis.com\"," +
            "oauth_consumer_key=\"" + key + "\"," +
            "oauth_nonce=\"" + nonce + "\"," +
            "oauth_signature_method=\"PLAINTEXT\"," +
            "oauth_timestamp=\"" + timestamp + "\"," +
            "oauth_version=\"1.0\"," +
            "oauth_signature=\"" + secret + "%26\""
        );
        string resultString = "";
        using (StreamReader read = new StreamReader(request.GetResponse().GetResponseStream(), true))
        {
            resultString = read.ReadToEnd();
        }
        return resultString;
    }
