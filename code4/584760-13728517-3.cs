    public async Task<bool> Push(TwitterAccount account)
    {
        var twitterService = new TwitterService(consumerKey, consumerSecret);
        twitterService.AuthenticateWith(account.AccessToken, account.AccessTokenSecret);
        var options = new SendTweetOptions {Status = string.Format("{0} {1}", account.Message.MessageContent, account.Message.ShortLink)};
        var status = twitterService.SendTweet(options);
        return status != null;
    }
