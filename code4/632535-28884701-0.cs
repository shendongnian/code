		public class ItemCache : Dictionary<string, Item>
    {
       private static ItemCache cache = new ItemCache();
	// Max number of hours to store an item in cache
        private static readonly int cacheDuration = 1; 
	// Max number of items that can be stored within cache
        private static readonly int maxCacheSize = 20; 
        public new void Add(string key, item thisItem)
        {
            base.Add(key, invoices);
            RemoveOld(cacheDuration);
            RemoveOldest(maxCacheSize);
        }
	// Removes items from the cache that are older than cacheDuration
        public void RemoveOld(int cache_duration)
        {
            foreach (KeyValuePair<string, Item> keyValue in this)
            {
                if (keyValue.Value.dateCreated < DateTime.Now.AddHours(-cacheDuration))
                {
                    this.Remove(keyValue.Key);
                }
            }
        }
	// If items in cache exceed maxCacheSize then remove oldest items
        public void RemoveOldest(int maxCacheSize)
        {
	    // If items in cache exceed maxCacheSize
            if(this.Count > maxCacheSize)
            {
		// Return a list of cache key values ordered by date
                IOrderedEnumerable<KeyValuePair<string, Item>> orderedKeys = from entry in this orderby entry.Value.dateCreated ascending select entry;
		// Removes each of the oldest items from the cache until the cache is no longer exceeding maxCacheSize
                foreach(KeyValuePair<string, Item> item in orderedKeys.Skip(maxCacheSize))
                {
                    this.Remove(item.Key);
                }
                orderedKeys = null;
                GC.Collect();
            }
        }
	// Adds item to cache, returns a guid for obtaining that item from the cache
        public static string AddItem(Item item)
        {
            string guid = Guid.NewGuid().ToString();
            cache.Add(guid, item);
            return guid;
        }
	
	// Retuns an item from the cache corresponding to the GUID key passed to the method
        public static Invoices GetItem(string guid)
        {
	    // Cleans cache
            cache.RemoveOld(cacheDuration);
            cache.RemoveOldest(maxCacheSize);
            if(cache.ContainsKey(guid))
            {
                return cache[guid];
            }
            else
            {
                return new Item();
            }
        }
    }
