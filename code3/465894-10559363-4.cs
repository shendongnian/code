    ConcurrentDictionary<string, object> _cache = new
      ConcurrenctDictionary<string, object>();
    public void GetOrAdd(string key)
    {
      return _cache.GetOrAdd(key, (k) => {
        //here 'k' is actually the same as 'key'
        return buildDataUsingGoodAmountOfResources();
      });
    }
