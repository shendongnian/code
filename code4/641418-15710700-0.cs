    class ActivityScope : IDisposable
    {
      Guid oldActivity;
      ActivityScope()
      {
        oldActivity = System.Diagnostics.CorrelationManager.ActivityId;
        System.Diagnostics.CorrelationManager.ActivityId = Guid.NewGuid();
      }
      public void Dispose()
      {
        System.Diagnostics.CorrelationManager.ActivityId = oldActivity;
      }
    }
    class LogicalOperationScope : IDisposable
    {
      public LogicalOperationScope(string logicalOperation)
      {
        System.Diagnostics.CorrelationManager.StartLogicalOperation(logicalOperation);
      }
 
      public void Dispose()
      {
        System.Diagnostics.CorrelationManager.StopLogicalOperation();
      }
    }
