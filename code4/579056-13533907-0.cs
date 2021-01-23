     using TweetSharp;
        
        TwitterService service = new TwitterService();
        IEnumerable<TwitterStatus> tweets = service.ListTweetsOnPublicTimeline();
        foreach (var tweet in tweets)
        {
            Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
        }
