    CacheItem item = cache.GetCacheItem("item");
    if (item == null) {
        CacheItemPolicy policy = new CacheItemPolicy {
            SlidingExpiration = TimeSpan.FromDays(1)
        }
        item = new CacheItem("item", someData);
        cache.Set(item, policy);
    }
