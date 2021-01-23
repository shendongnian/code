        public List<User> GetUsers()
        {
            var cache = System.Runtime.Caching.MemoryCache.Default;
            if (cache["MainADList"] == null)
            {
                // Rebuild cache. Perhaps for Multithreading, you can do object locking
                var cachePolicy = new System.Runtime.Caching.CacheItemPolicy() { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(30) };
                var users = Uf.GetUsers();
                cache.Add(new System.Runtime.Caching.CacheItem("MainADList", users), cachePolicy);
                return users;
            }
            return cache["MainADList"] as List<User>; 
        }
