    private void RunQuery(QueryState queryState)
    {
      // Start the operation.
      var asyncResult = queryState.Query.BeginExecuteSegmented(NoopAsyncCallback, queryState);
      // Register a callback.
      RegisteredWaitHandle shared = null;
      RegisteredWaitHandle produced = ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle,
        (state, timedout) =>
        {
          var asyncResult = opState as IAsyncResult;
          var state = asyncResult.AsyncState as QueryState;
          while (true)
          {
            // Keep reading until the value is no longer null.
            RegisteredWaitHandle consumed = Interlocked.CompareExchange(ref shared, null, null);
            if (consumed != null)
            {
              consumed.Unregister(asyncResult.AsyncWaitHandle);
              break;
            }
          }
        }, asyncResult, queryTimeout, true);
    
      // Publish the RegisteredWaitHandle so that the callback can see it.
      Interlocked.CompareExchange(ref shared, produced, null);
    }
    
