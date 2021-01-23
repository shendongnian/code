    OAuth.Manager oauth;
    AuthSettings settings;
    public void Foo()
    {
        oauth = new OAuth.Manager();
        oauth["consumer_key"] = TWITTER_CONSUMER_KEY;
        oauth["consumer_secret"] = TWITTER_CONSUMER_SECRET;
        settings = AuthSettings.ReadFromStorage();
        if (VerifyAuthentication())
        {
            Tweet("Hello, World");
        }
    }
    
    private void Tweet(string message)
    {
        var url = "http://api.twitter.com/1/statuses/update.xml?status=" + message;
        var authzHeader = oauth.GenerateAuthzHeader(url, "POST");
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.PreAuthenticate = true;
        request.AllowWriteStreamBuffering = true;
        request.Headers.Add("Authorization", authzHeader);
        using (var response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ...
            }
        }
    }
    
    private bool VerifyAuthentication()
    {
        if (!settings.Completed)
        {
            var dlg = new TwitterAppApprovalForm(); // your form with an embedded webbrowser
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                settings.access_token = dlg.AccessToken;
                settings.token_secret = dlg.TokenSecret;
                settings.Save();
            }
            if (!settings.Completed)
            {
                MessageBox.Show("You must approve this app for use with Twitter\n" +
                                "before updating your status with it.\n\n",
                                "No Authorizaiton for TweetIt",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }
        }
        
        // apply stored information into the oauth manager
        oauth["token"]           = settings.access_token;
        oauth["token_secret"]    = settings.token_secret;
        return true;
    }
