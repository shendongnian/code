     private TaskScheduler taskScheduler;
     
     public void OperationAsync()
     {
         Task.Factory.StartNew(
             LongRunningOperation,
             new CancellationToken(),
             TaskCreationOptions.None, 
             taskScheduler);
     }
