    var config = new NameValueCollection();  
    var cache = new MemoryCache("myMemCache", config);  
    cache.Add(new CacheItem("a", "b"),  
        new CacheItemPolicy  
        {  
            Priority = CacheItemPriority.NotRemovable,  
            SlidingExpiration=TimeSpan.FromMinutes(30)  
        }); 
