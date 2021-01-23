    public class Twitter
    {
        private List<String> tweetList;
        private String[] breakWords;
        private ulong maxID = 0000;
        private ulong sinceID = 3396455589; //oldest tweetID
        private void progressTweet(int i)
        {
            var statusTweets =
                   from tweet in twitterCtx.Status
                   where tweet.Type == StatusType.User &&
                         tweet.Count == 200 &&
                         tweet.SinceID == sinceID &&
                         tweet.ScreenName == "nyptweets"
                   select tweet;
    
            if (i == 0)
                tweetList.Add(statusTweets.ToList().ToString());
            else
                tweetList.Add(statusTweets.Where(x => x.MaxID == maxID).ToList().ToString());
    
            breakWords = tweetList[tweetList.Count - 1].Split(' ');
            maxID = Convert.ToUInt64(breakWords[5].ToString());
        }
    
        void GetUserTimeLine(TwitterContext ctx)
        {
            tweetList = new List<String>();
    
            for (int i = 0; i < 5; i++)
                progressTweet(i);
    
            File.WriteAllLines(@"C:\temp\Tweet.log", tweetList);
        }
    }
