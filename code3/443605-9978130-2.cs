    private class AsyncResult : IAsyncResult
    {
      public AsyncResult()
      {
        doneEvent = new ManualResetEvent(false);
      }
      public object AsyncState
      {
        get { return (state); }
        set { state = value; }
      }
      public WaitHandle AsyncWaitHandle
      {
        get { return (doneEvent); }
      }
      public bool CompletedSynchronously
      {
        get { return (false); }
      }
      public bool IsCompleted
      {
        get { return (completed); }
      }
      public void Complete()
      {
        completed = true;
        doneEvent.Set();
      }
      public Exception Exception { get; set; }
      public SqlDataReader Reader { get; set; }
      private object state;
      private bool completed;
      private ManualResetEvent doneEvent;
    }
    public static IAsyncResult BeginQuery(this DataContext ctx, IQueryable query,
      AsyncCallback callback, object state)
    {
      AsyncResult localResult = new AsyncResult();
      localResult.AsyncState = state;
      SqlCommand command = ctx.GetCommand(query) as SqlCommand;
      command.BeginExecuteReader(result =>
      {
        try
        {
          SqlDataReader reader = command.EndExecuteReader(result);
          localResult.Reader = reader;
        }
        catch (Exception ex)
        {
          // Needs to be rethrown to the caller...
          localResult.Exception = ex;
        }
        finally
        {
          // Need to call the caller...
          localResult.Complete();
          if (callback != null)
          {
            callback(localResult);
          }
        }
      }, null);
      return (localResult);
    }
    public static IEnumerable<T> EndQuery<T>(this DataContext ctx,
      IAsyncResult result)
    {
      AsyncResult localResult = (AsyncResult)result;
      if (localResult.Exception != null)
      {
        throw localResult.Exception;
      }
      return (ctx.Translate<T>(localResult.Reader));
    }
