    protected void btnTweet_Click(object sender, EventArgs e)
    {
     string oauthAccessToken = Session["twtoken"].ToString();
     string oauthAccessTokenSecret = Session["twsecret"].ToString();
     OAuthHelper oauthhelper = new OAuthHelper();
     oauthhelper.TweetOnBehalfOf(oauthAccessToken, oauthAccessTokenSecret, txtTweet.Text);
     if (string.IsNullOrEmpty(oauthhelper.oauth_error))
          Response.Write("Twit Posted Successfully");
     else
          Response.Write(oauthhelper.oauth_error);
    }
