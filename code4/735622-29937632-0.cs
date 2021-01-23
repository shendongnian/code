      public static void Tweet(string tweet)
    {
        var consumerKey = "me";
        var consumerSecret = "me";
        string accessToken = "me-me";
        string AccessTokenSecret = "me";
        TwitterService service = new TwitterService(consumerKey, consumerSecret, accessToken, AccessTokenSecret);
           //service.AuthenticateWith(accessToken, AccessTokenSecret);
        SendTweetOptions options = new SendTweetOptions();
        options.Status = tweet;
        service.SendTweet(options);
    }
