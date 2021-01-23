    public class MyImplementation : IMyInterface
    {
      public Task<TMyResult> GetDataAsync()
      {
        TMyResult ret = ...;
        return Task.FromResult(ret);
      }
    }
