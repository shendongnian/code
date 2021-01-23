        /// <summary>
        /// Places an item into the cache using absolute expiration.
        /// </summary>
        /// <param name="key">Key of the item being inserted</param>
        /// <param name="item">Item to insert</param>
        /// <param name="expireTime">Absolute expiration time of the item</param>
        public static void InsertIntoCacheAbsoluteExpiration(string key, object item, DateTime expireTime)
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            lock (LOCK)
            {
                HttpRuntime.Cache.Remove(key);
                HttpRuntime.Cache.Add(
                    key,
                    item,
                    null,
                    expireTime,
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    System.Web.Caching.CacheItemPriority.Normal,
                    null);
            }
        }
