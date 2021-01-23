    // Or in a repository or whatever...
    public static class SharedData
    {
      public static AsyncLazy<Dictionary<int, string>> MyDictionary =
          new AsyncLazy<Dictionary<int, string>>(async () =>
          {
            var ret = new Dictionary<int, string>();
            await MyLibrary.FillDictionary(ret);
            return ret;
          });
    }
