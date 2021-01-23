    class Program
    {
        private static void Main()
        {
            var ads = new[]
            {
                "Sony Ericsson Arc silver",
                "Sony Ericsson Play R800I",
                "Oneword",
            };
            
            var feedItems = new[]
            {
                "Sony Ericsson Xperia Arc Silver",
                "Nokia Lumia 900",
                "Sony Ericsson Xperia Play R800i Black",
            };
            var results = from ad in ads
                          from feedItem in feedItems
                          where isMatch(ad, feedItem)
                          select new
                          {
                              AdHeadline = ad,
                              MatchingFeed = feedItem,
                          };
            foreach (var result in results)
            {
                Console.WriteLine(
                    "AdHeadline = {0}, MatchingFeed = {1}",
                    result.AdHeadline,
                    result.MatchingFeed
                );
            }
        }
        public static bool isMatch(string ad, string feedItem)
        {
            var manufacturerWords = new[] { "sony", "ericsson", "nokia" };
            ad = ad.ToLower();
            feedItem = feedItem.ToLower();
            var adWords = Regex.Split(ad, @"\W+").Except(manufacturerWords);
            var feedItemWords = Regex.Split(feedItem, @"\W+").Except(manufacturerWords);
            var isMatch = adWords.Count(feedItemWords.Contains) >= 2;
            return isMatch;
        }
    }
