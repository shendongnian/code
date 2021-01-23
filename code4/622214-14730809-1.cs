    public void getProfile(MyProgressBar myprogressbar)
    {
        var auth = new SingleUserAuthorizer
        {
            Credentials = new InMemoryCredentials
            {
                ConsumerKey = GlobalVariables.ConsumerKey,
                ConsumerSecret = GlobalVariables.ConsumerSecret,
                AccessToken = GlobalVariables.AccessToken,
                OAuthToken = GlobalVariables.AccessTokenSecret
            }
        };
        using (var twitterCtx = new TwitterContext(auth, "https://api.twitter.com/1/", "https://search.twitter.com/"))
        {
            //Log
            twitterCtx.Log = Console.Out;
            var queryResponse = (from tweet in twitterCtx.Status
                                 where tweet.Type == StatusType.User && tweet.ScreenName == GlobalVariables.ScreenName
                                 select tweet);
            queryResponse.AsyncCallback(tweets =>
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    var publicTweets = (from tweet in tweets
                                        select tweet).FirstOrDefault();
                    s.TwitterName = publicTweets.User.Name.ToString();
                    s.TwitterScreenName = "@" + GlobalVariables.ScreenName;
                    s.TwitterDescription = publicTweets.User.Description.ToString();
                    s.TwitterStatus = publicTweets.User.StatusesCount.ToString() + " Tweets / " + publicTweets.User.FriendsCount.ToString() + " Following / " + publicTweets.User.FollowersCount.ToString() + " Followers";
                    s.TwitterImage = publicTweets.User.ProfileImageUrl.ToString();
                    myprogressbar.ShowProgressBar = false;
                })).SingleOrDefault();
        }
    }
