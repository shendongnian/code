    private void Foo()
    {
      var signals = new List<ManualResetEvent>();
    
      for (int i = 0; i < 15; i++)
      {
        var signal = new ManualResetEvent(false);
        var thread = new Thread(() => { Method(); signal.Set(); });
        thread.Start();
      }
    
      var completionTask = new Thread(() =>
      {
        WaitHandle.WaitAll(signals.ToArray());
        CompletionWork();
      });
    
    }
    
    private void Method()
    {
    }
    
    private void CompletionWork()
    {
    }
