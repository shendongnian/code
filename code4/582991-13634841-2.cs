    // storing SynchronizationContext in the private field of your form
    private SynchronizationContext _syncContext = SyncrhonizationContext.Current;
    
    private void MethodFromTheSeparateThread()
    {
      // Marshaling control to UI thread
      _syncContext.Post(d =>
                {
                    // Put all your code that access UI elements here
                }, null);
    }
