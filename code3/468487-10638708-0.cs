    var cts = new CancellationTokenSource();
    var token = cts.Token;
    
    Task.Factory.StartNew(
      () =>
      {
        foreach (MyClass detail in MyclassList)
        {
          ct.ThrowIfCancellationRequested();
          DoWork(detail);
        }
      }, cts.Token); 
