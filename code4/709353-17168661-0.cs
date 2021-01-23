        var objTwitterService = new TwitterService(_consumerKey, _consumerSecret);
        objTwitterService.AuthenticateWith(_accessToken, _accessTokenSecret);
        SearchOptions options = new SearchOptions { Q = strHashtag, Resulttype = TwitterSearchResultType.Recent };
        var searchedTweets = objTwitterService.Search(options);
        if (searchedTweets != null)
        {
          foreach (var tweet in searchedTweets.Statuses)
          {
            long strPostId = tweet.Id;
            String strPostMessage = tweet.Text;
            DateTime dtPostCreatedAt = tweet.CreatedDate;
          }
        }
