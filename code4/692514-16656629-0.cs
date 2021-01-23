    public class Foo
    {
      private TaskCompletionSource<object> _signal = new TaskCompletionSource<object>();
      public void UnblockDoSomething()
      {
        DoWork();
        _signal.SetResult(null);
        _signal = new TaskCompletionSource<object>();
      }
      public async Task DoSomethingAsync()
      {
        var continueSignal = _signal.Task;
        DoSomeWork();
        await continueSignal;
        DoMoreWork();
      }
    }
