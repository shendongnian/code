    public class MyBackingStore : IBackingStore
    {
        public List<string> keys = new List<string>();
        public void Add(CacheItem newCacheItem)
        {
            keys.Add(newCacheItem.Key);
        }
        public void Remove(string key)
        {
            keys.Remove(key);
        }
    }
