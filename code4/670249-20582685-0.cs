    // No MaxHandle limitation ;)
    for (var offset = 0; offset <= count; offset++)
    {
        // Initialize the reset event
        var resetEvent = new ManualResetEvent(false);
    
        // Queue action in thread pool for each item in the list
        long counter = count;
        // use a thread for each item in the chunk
        int i = 0;
        foreach (var item in list)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((object data) =>
                          {
                              int methodIndex =
                                  (int) ((object[]) data)[0];
    
                              // Execute the method and pass in the enumerated item
                              action((T) ((object[]) data)[1]);
    
                              // Decrements counter atomically
                              Interlocked.Decrement(ref counter);
    
                              // If we're at 0, then last action was executed
                              if (Interlocked.Read(ref counter) == 0)
                              {
                                  resetEvent.Set();
                              }
                          }), new object[] {i, item});
        }
    
        // Wait for the single WaitHandle
        // which is only set when the last action executed
        resetEvent.WaitOne();
    }
