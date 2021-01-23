      public List<FeedAndSource> DownloadAll(RssSubscription subscription)
        {
            var feeds = var feeds = new SynchronizedCollection<FeedAndSource>();
            var tasks = new List<Task>();
            foreach (var sub in subscription.Items)
            {
                var r = Task.Factory.StartNew(() =>
                    {
                        var res = Fetch(sub.XmlUri);
                        if (res.IsFound)
                            feeds.Add(new FeedAndSource(sub, res.Item));
                    });
                tasks.Add(r);
            }
            Task.WaitAll(tasks.ToArray());
            return feeds.toList();
        }
