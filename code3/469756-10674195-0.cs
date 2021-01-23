    public void AddFeed(string id)
    {
        FeedClassExample fce = new FeedClassExamle();
        if (!Feeds.TryAdd(id, fce))
        {
            fce.Dispose();
        } 
        Feeds[id].Start();
    }
