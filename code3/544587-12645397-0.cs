    static MemoryCache MemCache;
    static int RefreshInterval = 1000;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (MemCache == null)
        {
            const string assembly = "System.Runtime.Caching, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
            var type = Type.GetType("System.Runtime.Caching.CacheExpires, " + assembly, true, true);
            var field = type.GetField("_tsPerBucket", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, TimeSpan.FromSeconds(1));
            type = typeof(MemoryCache);
            field = type.GetField("s_defaultCache", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, null);
            MemCache = new MemoryCache("MemCache");
        }
        if (!MemCache.Contains("cacheItem"))
        {
            var cacheObj = new object();
            var policy = new CacheItemPolicy
            {
                UpdateCallback = new CacheEntryUpdateCallback(CacheEntryUpdate),
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMilliseconds(RefreshInterval)
            };
            var cacheItem = new CacheItem("cacheItem", cacheObj);
            MemCache.Set("cacheItem", cacheItem, policy);
        }
    }
    private void CacheEntryUpdate(CacheEntryUpdateArguments args)
    {
        var cacheItem = MemCache.GetCacheItem(args.Key);
        var cacheObj = cacheItem.Value;
        
        cacheItem.Value = cacheObj;
        args.UpdatedCacheItem = cacheItem;
        var policy = new CacheItemPolicy
        {
            UpdateCallback = new CacheEntryUpdateCallback(CacheEntryUpdate),
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMilliseconds(RefreshInterval)
        };
        args.UpdatedCacheItemPolicy = policy;
    }
