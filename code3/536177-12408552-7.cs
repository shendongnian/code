    public CacheItem Get(string key)
    {
        lock (SynchObj)
        {
            CacheItem item;
            if (!Cache.TryGetValue(key, out item))
            {
                item = new CacheItem();
                item.ExpensiveLoad();
                Cache.Add(key, item);
            }
            return item;
        }
    }
