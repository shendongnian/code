    public void ProcessRequest(HttpContext context)
    {
        // get these from somewhere nice and secure...
        var key = ConfigurationManager.AppSettings["twitterConsumerKey"];
        var secret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
        var server = HttpContext.Current.Server;
        var bearerToken = server.UrlEncode(key) + ":" + server.UrlEncode(secret);
        var b64Bearer = Convert.ToBase64String(Encoding.Default.GetBytes(bearerToken));
        using (var wc = new WebClient())
        {
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            wc.Headers.Add("Authorization", "Basic " + b64Bearer);
            var tokenPayload = wc.UploadString("https://api.twitter.com/oauth2/token", "grant_type=client_credentials");
            var rgx = new Regex("\"access_token\"\\s*:\\s*\"([^\"]*)\"");
            // you can store this accessToken and just do the next bit if you want
            var accessToken = rgx.Match(tokenPayload).Groups[1].Value;
            wc.Headers.Clear();
            wc.Headers.Add("Authorization", "Bearer " + accessToken);
    
            const string url = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=YourTwitterHandle&count=4";
            // ...or you could pass through the query string and use this handler as if it was the old user_timeline.json
            // but only with YOUR Twitter account
    
            var tweets = wc.DownloadString(url);
            //do something sensible for caching here:
            context.Response.AppendHeader("Cache-Control", "public, s-maxage=300, max-age=300");
            context.Response.AppendHeader("Last-Modified", DateTime.Now.ToString("r", DateTimeFormatInfo.InvariantInfo));
            context.Response.AppendHeader("Expires", DateTime.Now.AddMinutes(5).ToString("r", DateTimeFormatInfo.InvariantInfo));
            context.Response.ContentType = "text/plain"; 
            context.Response.Write(tweets);
        }
    }
