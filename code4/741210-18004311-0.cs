    public List<FeedItem> Items {
      get { return _Items; }
      set { _Items = value; }
    }
    feedData.Items = db.Table<FeedItem>()
                       .Where(item => item.FeedId = feedData.Id).ToList();
