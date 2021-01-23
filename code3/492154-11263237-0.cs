    public class AsyncLazy<T> : Lazy<Task<T>> 
    { 
      public AsyncLazy(Func<T> valueFactory) : 
          base(() => Task.Run(valueFactory)) { }
      public AsyncLazy(Func<Task<T>> taskFactory) : 
          base(() => Task.Run(taskFactory)) { } 
      public TaskAwaiter GetAwaiter() { return Value.GetAwaiter(); } 
    }
    public static class ExposeSomeInterestingItemsFactory
    {
      public static AsyncLazy<ExposeSomeInterestingItems> Instance
      {
        get { return _instance; }
      }
      private static AsyncLazy<ExposeSomeInterestingItems> _instance =
          new AsyncLazy<ExposeSomeInterestingItems>(() => new ExposeSomeInterestingItems());
    }
    public class ExposeSomeInterestingItems
    {
      public ExposeSomeInterestingItems()
      {
        // This takes some time to load
        this._interestingItems = InterestingItemsLoader.LoadItems();
      }
      public InterestingItem GetItem(string id)
      {
        // Regular logic. No "delays".
      }
    }
    ...
    var exposeSomeInterestingItems = await ExposeSomeInterestingItemsFactory.Instance;
    var item = exposeSomeInterestingItems.GetItem("id");
