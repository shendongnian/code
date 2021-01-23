public T GetFromCache<T>(string key, Func<T> valueFactory) 
{
    T value = (T)cache.Get(key);
    if (value != null)
    {
        return value;
    }
    var newValue = new Lazy<T>(valueFactory);
    // the line belows returns existing item or adds the new value if it doesn't exist
    var oldValue = (Lazy<T>)cache.AddOrGetExisting(key, newValue, MemoryCache.InfiniteExpiration);
    return (oldValue ?? newValue).Value; // Lazy<T> handles the locking itself
}
  [1]: https://github.com/microsoft/referencesource/blob/e0bf122d0e52a42688b92bb4be2cfd66ca3c2f07/System.Runtime.Caching/System/Caching/MemoryCacheStore.cs#L151
