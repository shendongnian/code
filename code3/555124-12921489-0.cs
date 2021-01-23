    // Or in a repository or whatever...
    public static class SharedData
    {
      public static Task<Dictionary<int, string>> MyDictionary;
    }
    ...
    Application_Start(..)
    {
      // Start the dictionary filling, but don't wait for it to complete.
      // Note that we're saving the Task, not await'ing it.
      MyDictionary = MyLibrary.GetDictionary();
    }
