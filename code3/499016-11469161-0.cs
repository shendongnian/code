    Twitterizer.OAuthTokens token = new Twitterizer.OAuthTokens();
    token.ConsumerKey = this.AppId;
    token.ConsumerSecret = this.AppSecret;
    token.AccessToken = userToken;
    token.AccessTokenSecret = userSecret;
    
    Twitterizer.TwitterResponse<Twitterizer.TwitterUser> response =
        Twitterizer.TwitterAccount.VerifyCredentials(token);
    
    if (String.IsNullOrEmpty(response.ErrorMessage))
    {
        //This is a valid token
    }
    else
    {
        //Invalid token
    }
