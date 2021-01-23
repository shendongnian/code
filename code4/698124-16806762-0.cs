    public ActionResult Tweet(string tweet)
            {
                var twitter = new WebConsumer(TwitterConsumer.ServiceDescription, this.TokenManager);
                // Process the response
                var accessTokenResponse = twitter.ProcessUserAuthorization();
    
                // Is Twitter calling back with authorization?
                if (Tweet_Token != null)
                {
                    string accessToken = Tweet_Token;
                    var tokenSecret = twitter.TokenManager.GetTokenSecret(accessToken);
                    TwitterPush tw = new TwitterPush(twitter_app, twitter_secret, accessToken, tokenSecret);
                    if (tweet != "")
                    {
                        var response = tw.UpdateStatus(tweet);
    
                    }
                    return View();
    
                }  return View();
            }
