    SemaphoreSlim queueToAccessQueue = new SemaphoreSlim(1);
    object queueLock = new object();
    long queuedRequests = 0;
    Task _loadingTask;
    public void RetrieveItems() {
      lock (queueLock) {
          queuedRequests++;
          if (queuedRequests == 1) { // 1 is the minimum size of the queue before another instance is queued
            _loadingTask = _loadingTask?.ContinueWith(async () => {
              RunTheMethodAgain();
              await queueToAccessQueue.WaitAsync();
              queuedRequests = 0; // indicates that the queue has been cleared;
              queueToAccessQueue.Release()
            }) ?? Task.Run(async () => {
              RunTheMethodAgain();
              await queueToAccessQueue.WaitAsync();
              queuedRequests = 0; // indicates that the queue has been cleared;
              queueToAccessQueue.Release();
            });
          }
      }
    }
    public void RunTheMethodAgain() {
      ** run the method again **
    }
