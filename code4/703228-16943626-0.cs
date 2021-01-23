    public List<T> CreateAndInitialize<T>(int size, Func<int, T> init)
    {
      var result = new List<T>();
      for (int i = 0; i < result.Count; ++i)
        result[i] = init(i);
      return result;
    }
