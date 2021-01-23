    public class InMemoryCache : ICacheService
    {
        public T Get<T>(string key, DateTime? expirationTime, Func<T> fetchDataCallback) where T : class
        {
            T item = HttpRuntime.Cache.Get(key) as T;
            if (item == null)
            {
                item = fetchDataCallback();
                HttpRuntime.Cache.Insert(key, item, null, expirationTime ?? DateTime.Now.AddMinutes(10), TimeSpan.Zero, CacheItemPriority.Normal, (
                    s, value, reason) =>
                    {
                        // recache old data so that users are receiving old cache while the new data is being fetched
                        HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero, CacheItemPriority.Normal, null);
                        Task.Factory.StartNew(fetchDataCallback);
                    });
            }
            return item;
        }
    }
