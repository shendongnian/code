    public static Task<MyClass> GetAsync(int key)
    {
      if (cache.Contains(key))
        return Task.FromResult(cache[key]);
      return CreateAndAddAsync(key);
    }
    private static async Task<MyClass> CreateAndAddAsync(int key)
    {
      var result = await CreateAsync(key);
      cache.Add(key, result);
      return result;
    }
