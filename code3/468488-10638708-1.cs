    var cts = new CancellationTokenSource();
    var token = cts.Token;
    
    var task = Task.Factory.StartNew(
      () =>
      {
        foreach (MyClass detail in MyclassList)
        {
          ct.ThrowIfCancellationRequested();
          DoWork(detail);
        }
      }, cts.Token); 
    // Do other stuff here.
    cts.Cancel(); // Request cancellation.
