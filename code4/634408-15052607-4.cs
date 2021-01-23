    private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
    private List<Object> items;
    private ConcurrentQueue<int> queue;
    private Timer timer;
    private void callback(object state)
    {
      int index = items.Count;
      this.rwLock.EnterWriteLock();
      try {
        // in this place, right here, there can be only ONE writer
        // and while the writer is between EnterWriteLock and ExitWriteLock
        // there can exist no readers in the following method (between EnterReadLock
        // and ExitReadLock)
        // we add the item to the List
        // AND do the enqueue "atomically" (as loose a term as thread-safe)
        items.Add(new object());
        if (true)//some condition here
          queue.Enqueue(index);
      } finally {
        this.rwLock.ExitWriteLock();
      }
      timer.Change(TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(-1));
    }
    //This can be called from any thread
    public IEnumerable<object> AccessItems()
    {
      List<object> results = new List<object>();
      this.rwLock.EnterReadLock();
      try {
        // in this place there can exist a thousand readers 
        // (doing these actions right here, between EnterReadLock and ExitReadLock)
        // all at the same time, but NO writers
        foreach (var index in queue)
        {
          this.results.Add ( this.items[index] );
        }        
      } finally {
        this.rwLock.ExitReadLock();
      }
      return results; // or foreach yield return you like that more :)
    }
