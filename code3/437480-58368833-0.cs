    var user = await Cached.Get(
          _cache, userName, 
          async () => _dbContext.LoadAsync<DbUser>(userName)));
**Implementation**
    public class CachedEntry<T>
    {
        public CachedEntry(T value)
        {
            Value = value;
        }
        public T Value { get; }
    }
    public static async Task<T> Get<T>(IMemoryCache cache, 
    string key, Func<Task<T>> getDelegate)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        var cachedEntry = cache.Get<CachedEntry<T>>(key);
        if (cachedEntry == null)
        {
           var result = await getDelegate();
           cachedEntry = new CachedEntry<T>(result);
           cache.Set(key, cachedEntry);
        }
        return cachedEntry.Value;
    }
