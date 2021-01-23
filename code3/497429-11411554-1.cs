    public class BaseRepository
    {
        protected readonly ICacheProvider CacheProvider;
        protected readonly bool ShouldUseCache;
        protected BaseRepository(IDataContext context, ICacheProvider cacheProvider)
        {
            CacheProvider = cacheProvider;
            ShouldUseCache = 
                CacheProvider != null && !(CacheProvider is NullCacheProvider);
        }
    }
