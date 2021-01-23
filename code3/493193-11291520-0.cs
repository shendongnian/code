    public void CreateCachedAccessToken(string requestToken)
        {
            string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            OAuthTokenResponse responseToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, requestToken);
            //Cache the UserId
            Session["GetCachedUserId"] = responseToken.UserId;
            OAuthTokens accessToken = new OAuthTokens();
            accessToken.AccessToken = responseToken.Token;
            accessToken.AccessTokenSecret = responseToken.TokenSecret;
            accessToken.ConsumerKey = ConsumerKey;
            accessToken.ConsumerSecret = ConsumerSecret;
            Session["AccessToken"] = accessToken;
        }
