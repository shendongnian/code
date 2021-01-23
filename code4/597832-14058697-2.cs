    /// <summary>
    /// Defines a base for items executable by WorkQueue
    /// </summary>
    public interface IWorkItem<TContext> where TContext : class
    {
      /// <summary>
      /// Invoked on an item to perform actual work. 
      /// For example: repaint grid from changed data source, refresh file, send email etc... 
      /// </summary>
      void PerformWork(TContext context);
    
      /// <summary>
      /// Invoked after successfull work execution - when no exception happened
      /// </summary>
      void WorkSucceeded();
    
      /// <summary>
      /// Invoked when either work execution or work success method threw an exception and did not succeed
      /// </summary>
      /// <param name="workPerformed">When true indicates that PerformWork() worked without exception but exception happened later</param>
      void WorkFailed(bool workPerformed, Exception error);
    
    }
    /// <summary>
    /// Defines contract for work queue that work items can be posted to
    /// </summary>
    public interface IWorkQueue<TContext> where TContext : class
    {
      /// <summary>
      /// Posts work item into the queue in natural queue order (at the end of the queue)
      /// </summary>
      void PostItem(IWorkItem<TContext> work);
     
      long ProcessedSuccessCount{get;}
      long ProcessedFailureCount{get;}
     
      TContext Context { get; }
    }
