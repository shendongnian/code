    public class Singleton
    {
      private static readonly AsyncLazy<Singleton> instance =
          new AsyncLazy<Singleton>(CreateAndLoadData);
      private Singleton() 
      {
      }
      // This method could also be an async lambda passed to the AsyncLazy constructor.
      private static async Task<Singleton> CreateAndLoadData()
      {
        var ret = new Singleton();
        await ret.LoadDataAsync();
        return ret;
      }
      public static AsyncLazy<Singleton> Instance
      {
        get { return instance; }
      }
    }
