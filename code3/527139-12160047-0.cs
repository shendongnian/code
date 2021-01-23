    // Here your long running operation
    private int LongRunningOperation()
    {
       Thread.Sleep(1000);
       return 42;
    }
    
    // This operation will be called for processing tasks results
    private void ProcessTaskResults(Task t)
    {
       // We'll call this method in UI thread, so Invoke/BeginInvoke
       // is not required
       this.textBox.Text = t.Result;
       
    }
    
    // Starting long running operation
    private void StartAsyncOperation()
    {
       // Starting long running operation using Task.Factory
       // instead of background worker.
       var task = Task.Factory.StartNew(LongRunningOperation);   
    
       // Subscribing to tasks continuation that calls
       // when our long running operation finished
       task.ContinueWith(t =>
       {
          ProcessTaskResults(t);
          StartOperation();
       // Marking to execute this continuation in the UI thread!
       }, TaskScheduler.FromSynchronizationContext);
    }
    
    // somewhere inside you form's code, like btn_Click:
    StartAsyncOperation();
