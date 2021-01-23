     public static void UploadTweet(string token, string tokensecreat, byte[] img, string Title)
            {
                Twitterizer.OAuthTokens tokens = new Twitterizer.OAuthTokens();
                tokens.AccessToken = token;
                tokens.AccessTokenSecret = tokensecreat;
                tokens.ConsumerKey = TWITTER_CONSUMER_KEY;
                tokens.ConsumerSecret = TWITTER_CONSUMER_SECRET;
                byte[] photo = img;
    
                TwitterResponse<TwitterStatus> response = TwitterStatus.UpdateWithMedia(tokens, Title, photo, new StatusUpdateOptions() { UseSSL = true, APIBaseAddress = "http://api.twitter.com/1.1/" });
                if (response.Result == RequestResult.Success)
                {
    
                }
                else
                {
    
                }
            }
