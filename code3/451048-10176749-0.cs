      CancellationTokenSource cts = new CancellationTokenSource();
      Task.Factory.StartNew(() =>
         {
              while(!cts.IsCancellationRequested)
              {
                   Thread.Sleep(5000);
                   DisplayWegingInfo();
                   CalculateTimen();
              }
         });
