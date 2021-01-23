            var oAuthConsumerKey = "key";
            var oAuthConsumerSecret = "secret";
            var oAuthUrl = "https://api.twitter.com/oauth2/token";
	    var screenname = "StackExchange";
	    // Do the Authenticate
            var authHeaderFormat = "Basic {0}";
            var authHeader = string.Format(authHeaderFormat,
                 Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +
                        Uri.EscapeDataString((oAuthConsumerSecret)))
                        ));
            var postBody = "grant_type=client_credentials";
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }
            authRequest.Headers.Add("Accept-Encoding", "gzip");
            WebResponse authResponse = authRequest.GetResponse();
	    // deserialize into an object
	    TwitAuthenticateResponse twitAuthResponse;
           using (authResponse)
           {
            using (var reader = new StreamReader(authResponse.GetResponseStream())) {
		    JavaScriptSerializer js = new JavaScriptSerializer();
		    var objectText = reader.ReadToEnd();
		    twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
		    }
	    }
	     // Do the avatar
            var avatarFormat =
                "https://api.twitter.com/1.1/users/show.json?screen_name={0}";
            var avatarUrl = string.Format(avatarFormat, screenname);
            HttpWebRequest avatarRequest = (HttpWebRequest)WebRequest.Create(avatarUrl);
            var timelineHeaderFormat = "{0} {1}";
            avatarRequest.Headers.Add("Authorization",
                                        string.Format(timelineHeaderFormat, twitAuthResponse.token_type,
                                                      twitAuthResponse.access_token));
            avatarRequest.Method = "Get";
            WebResponse timeLineResponse = avatarRequest.GetResponse();
            var avatarJson = string.Empty;
            using (authResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    avatarJson = reader.ReadToEnd();
                }
            }
