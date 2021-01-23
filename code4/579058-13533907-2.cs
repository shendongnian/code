    using TweetSharp;
    
    TwitterService service = new TwitterService();
    IAsyncResult result = service.ListTweetsOnPublicTimeline(
        (tweets, response) =>
            {
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    foreach (var tweet in tweets)
                    {
                        Console.WriteLine("{0} said '{1}'", tweet.User.ScreenName, tweet.Text);
                    }
                }
            });
