    foreach (var item in feed.Items)
    {
        yield return new MyFeedItem
                            {
                                Title = item.Title.Text,
                                Link = item.Links.First().Uri,
                                Description = item.Summary.Text,
                                PubDate = item.PublishDate
                            };
    }
