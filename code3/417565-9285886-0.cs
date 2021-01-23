    public class MongoCacheStore
    {
        public void RegisterClass<T>() where T : class, ICacheable
        {
            BsonClassMap.RegisterClassMap<T>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty("CacheId");
            });
        }
    }
