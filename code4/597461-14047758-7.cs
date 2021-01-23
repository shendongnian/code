    public class InMemoryCache : ICacheService
    {
        private int minutes = 15;
        public T Get<T>(string cacheID, Func<T> getItemCallback) where T : class
        {
            T item = HttpRuntime.Cache.Get(cacheID) as T;
            if (item == null)
            {
                item = getItemCallback();
                HttpRuntime.Cache.Insert(
                    cacheID,
                    item,
                    null,
                    DateTime.Now.AddMinutes(minutes),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return item;
        }
        public void Clear()
        {
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
            while (enumerator.MoveNext())
                HttpRuntime.Cache.Remove(enumerator.Key.ToString());
        }
    }
