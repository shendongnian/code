      private readonly CancellationTokenSource cts = new CancellationTokenSource();
    
      public void Start()
      {
         blockingCollection= new BlockingCollection<int>();
         var task = Task.Factory.StartNew(ProcessData, cts.Token);
      }
    
      private void ProcessData()
      {
        foreach(var item in blockingCollection.GetConsumingEnumerable(cts.Token))
        {  
            cts.Token.ThrowIfCancellationRequested();
    
            // ...
        }
      }
    
      public void Cancel()
      {
          cts.Cancel();
      }
