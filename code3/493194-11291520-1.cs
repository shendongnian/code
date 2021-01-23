    public OAuthTokens GetCachedAccessToken()
        {
            if (Session["AccessToken"] != null)
            {
                return (OAuthTokens)(Session["AccessToken"]);
            }
            else
            {
                return null;
            }
        }
    TwitterStatus.Update(GetCachedAccessToken(), txtTweet.Trim());
