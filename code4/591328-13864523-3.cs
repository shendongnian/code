    private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        SyndicationFeed feed;
        using (XmlReader reader = XmlReader.Create(e.Result))
        {
            feed = SyndicationFeed.Load(reader);
            NewsFeed.ItemsSource = ParseFeed(feed);
        }
    }
    private static IEnumerable<MyFeedItem> ParseFeed(SyndicationFeed feed)
    {
        return feed.Items.Select(item => new MyFeedItem
                                                {
                                                    Title = item.Title.Text,
                                                    Link = item.Links.First().Uri,
                                                    Description = item.Summary.Text,
                                                    PubDate = item.PublishDate
                                                });
    }
