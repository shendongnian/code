    internal class SomeEventArgs : EventArgs 
    {
      public dynamic WorkerResult { get; private set; }
      
      public SomeEventArgs(dynamic workerResult) 
      {
        WorkerResult = workerResult;
      }
    }
