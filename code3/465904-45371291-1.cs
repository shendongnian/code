    /// <summary>
    /// Get a JSON object from cache or serialize it if it doesn't exist yet.
    /// </summary>
    private static readonly Func<object, string> GetJson =
        GetOrRefreshCacheFactory<object, string>("json-cache", JsonConvert.SerializeObject);
    var json = GetJson(new { foo = "bar", yes = true });
