    public List<T> CreateAndInitialize<T>(int size, Func<int, T> init)
    {
      var result = new List<T>(size);
      for (int i = 0; i < size; ++i)
        result.Add(init(i));
      return result;
    }
