            object data = new object();
            string key = "UniqueIDOfDataObject";
            //Insert empty cache item with absolute timeout
            string[] absKey = { "Absolute" + key };
            MemoryCache.Default.Add("Absolute" + key, new object(), DateTimeOffset.Now.AddMinutes(10));
            //Create a CacheEntryChangeMonitor link to absolute timeout cache item
            CacheEntryChangeMonitor monitor = MemoryCache.Default.CreateCacheEntryChangeMonitor(absKey);
            
            //Insert data cache item with sliding timeout using changeMonitors
            CacheItemPolicy itemPolicy = new CacheItemPolicy();
            itemPolicy.ChangeMonitors.Add(monitor);
            itemPolicy.SlidingExpiration = new TimeSpan(0, 60, 0);
            MemoryCache.Default.Add(key, data, itemPolicy, null);
