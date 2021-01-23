    public async Task<bool> Push(TwitterAccount account)
    {
        var twitterService = new TwitterService(consumerKey, consumerSecret);
        twitterService.AuthenticateWith(account.AccessToken, account.AccessTokenSecret);
        var status = twitterService.SendTweet(account.MessageContent);
        return status != null;
    }
