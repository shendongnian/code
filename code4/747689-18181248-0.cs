    var cache = new MemoryCache("PathCache", new NameValueCollection()
    {
      { "CacheMemoryLimitMegabytes", "256" }, // max 256 MB
      { "PhysicalMemoryLimit", "50" } // max 50% of RAM
    });
    
    // cache an item
    cache["MyPath"] = "...";
    
    // check, whether the cache contains an item
    if (cache.Contains("MyPath"))
    {
      // cache hit!
      var cachedPath = cache["MyPath"];
    }
    
    // ensure cache is released somewhere in your code
    cache.Dispose();
