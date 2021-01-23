    public static class Feeds
    {
        private static readonly Dictionary<string, FeedElement> feeds;
        static Feeds()
        {
            feeds = new Dictionary<string, FeedElement>();
            var config = ConfigurationManager.GetSection("feedRetriever") as FeedRetrieverSection;
            foreach (FeedElement feed in config.Feeds)
            {
                feeds.Add(feed.Name, feed);
            }
        }
        static public FeedElement GetFeed(string name)
        {
            return feeds[name];
        }
    }
