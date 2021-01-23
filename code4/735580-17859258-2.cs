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
                        // fetch data async and insert into cache again
                        Task.Factory.StartNew(() => HttpRuntime.Cache.Insert(key, fetchDataCallback(), null, expirationTime ?? DateTime.Now.AddMinutes(10), TimeSpan.Zero, CacheItemPriority.Normal, null));
                    });
            }
            return item;
        }
    }
