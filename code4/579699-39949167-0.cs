    public string UpdateStatus(string status)
    {
        var oauth_version = "1.0";
        var oauth_signature_method = "HMAC-SHA1";
    
        // unique request details
        var oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        var oauth_timestamp = Convert.ToInt64(
            (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
                .TotalSeconds).ToString();
    
        var resource_url = "https://api.twitter.com/1.1/statuses/update.json";
    
        // create oauth signature
        var baseString = string.Format(
            "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}&" +
            "oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}",
            config.OAuthConsumerKey,
            oauth_nonce,
            oauth_signature_method,
            oauth_timestamp,
            config.OAuthToken,
            oauth_version,
            Uri.EscapeDataString(status));
    
    
        baseString = string.Concat("POST&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));
    
        var compositeKey = string.Concat(Uri.EscapeDataString(config.OAuthConsumerSecret),
        "&", Uri.EscapeDataString(config.OAuthTokenSecret));
    
        string oauth_signature;
        using (var hasher = new HMACSHA1(Encoding.ASCII.GetBytes(compositeKey)))
        {
            oauth_signature = Convert.ToBase64String(hasher.ComputeHash(Encoding.ASCII.GetBytes(baseString)));
        }
    
        // create the request header
        var authHeader = string.Format(
            "OAuth oauth_consumer_key=\"{0}\", oauth_nonce=\"{1}\"," +
            " oauth_signature=\"{2}\", oauth_signature_method=\"{3}\", " +
            "oauth_timestamp=\"{4}\",  oauth_token=\"{5}\", " +
            "oauth_version=\"{6}\"",
            Uri.EscapeDataString(config.OAuthConsumerKey),
            Uri.EscapeDataString(oauth_nonce),
            Uri.EscapeDataString(oauth_signature),
            Uri.EscapeDataString(oauth_signature_method),
            Uri.EscapeDataString(oauth_timestamp),
            Uri.EscapeDataString(config.OAuthToken),
            Uri.EscapeDataString(oauth_version)
        );
    
    
        var postBody = "status=" + Uri.EscapeDataString(status);
        ServicePointManager.Expect100Continue = false;
    
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = Encoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }
    
            WebResponse response = request.GetResponse();
            Stream reqStream = response.GetResponseStream();
            StreamReader reqStreamReader = new StreamReader(reqStream);
            return reqStreamReader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return ex + ":\n" + ex.Message;
        }
    }
