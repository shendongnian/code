    public class MemoryCacheService : IMemoryCacheService
    {
        public MemoryCacheService()
        {
            MemoryCache = new MemoryCache();
        }
        public MemoryCache MemoryCache
        {
            get;
            set;
        }
    }
