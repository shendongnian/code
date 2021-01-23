    class XYZType
    {
        NewsType[] news { get; set; }
        public class NewsType
        {
            FBType fb { get; set; }
            FeedType feed { get; set; }
            TweetType tw { get; set; }
            public class FBType
            {
                string message { get; set; }
                string user { get; set; }
            }
            public class FeedType
            {
                string title { get; set; }
                string abstract_ { get; set; }
            }
            public class TweetType
            {
                string tweetid { get; set; }
                string user { get; set; }
            }	
        }
    }
