    public class PersistentSession : IPersistentSession
    {
        // prepare Dependency Injection
        public static ICache cacheProvider { get; set; }
        public static bool SetSessionValue(string key, string value)
        {
            return cacheProvider.PutToCache(key, value);
        }
        public static bool SetSessionValue(string key, string value, TimeSpan expirationTimeSpan)
        {
            return cacheProvider.PutToCache(key, value, expirationTimeSpan);
        }
        public static string FetchSessionValue(string key)
        {
            return cacheProvider.FetchFromCache(key);
        }
    }
