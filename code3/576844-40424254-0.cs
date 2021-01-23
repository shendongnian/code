    List<EmailData> result = null;
    
    ObjectCache cache = MemoryCache.Default;
    var key = string.Concat(title, ":", language);
    var item = cache.GetCacheItem(key);
    
    if (item != null)
      return item.Value as List<EmailData>;
    using (var connection = _connectionFactory.OpenConnection())
    {
      result = connection.Query<EmailData>(sql, new { title, language }).ToList();
    }
    var cachingPolicy = new CacheItemPolicy
    {
      AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(_cacheExpirationIntervalInMinutes)
    };
    cache.Set(new CacheItem(key, result), cachingPolicy);
    return result;
