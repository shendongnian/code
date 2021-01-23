    public class Foo
    {
      private readonly AsyncLock _mutex = new AsyncLock();
      private readonly AsyncConditionVariable _cv = new AsyncConditionVariable(_mutex);
      public void UnblockDoSomething()
      {
        using (await _mutex.LockAsync())
        {
          DoWork();
          _cv.Notify();
        }
      }
      public async Task DoSomethingAsync()
      {
        using (await _mutex.LockAsync())
        {
          DoSomeWork();
          await _cv.WaitAsync();
          DoMoreWork();
        }
      }
    }
