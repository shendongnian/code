    public class Foo
    {
      private readonly SemaphoreSlim _mutex = new SemaphoreSlim(0);
      public void UnblockDoSomething()
      {
        DoWork();
        _mutex.Release();
      }
      public async Task DoSomethingAsync()
      {
        DoSomeWork();
        await _mutex.WaitAsync();
        DoMoreWork();
      }
    }
