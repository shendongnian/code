     var twitterCtx = new TwitterContext(auth);
                var statusTweets =
               from tweet in twitterCtx.Status
               where tweet.Type == StatusType.User
                     && tweet.ScreenName == "ScreenName"
               select tweet;
                _model.Tweets.Clear();
                foreach (var item in statusTweets)
                {
                    _model.Tweets.Add(new Tweet
                 {
                     Name = item.User.Name,
                     Message = item.Text,
                     Image = new BitmapImage(new Uri(item.User.ProfileImageUrl)),
                 });
