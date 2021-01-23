    public void CheckCarts(string key, object value, CacheItemRemovedReason reason) {
         // Insert your code here to check for expired carts
         (...)
         // We add the entry again to the cache, so that this method will be called again in 5 minutes.
         HttpContext.Current.Cache.Add("Task", "1", null, 
                DateTime.MaxValue, TimeSpan.FromMinutes(5), 
                CacheItemPriority.Normal, new CacheItemRemovedCallback(CheckCarts));
    }
