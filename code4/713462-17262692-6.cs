    // global success indicator
    private const int NotDone = 0;
    private const int AllDone = 1;
    private int _allDone = NotDone;
    private GeneralSearchFunction(bool directionForward) {
      bool iFoundIt = false;
      ... do some search operations that won't take much time
      if (iFoundIt) {
        // set _allDone to AllDone!
        Interlocked.Exchange(ref _allDone, AllDone);
        return;
      }
      ... do more work
      // after one or a few iterations, if this thread is still going
      //   see if another thread has set _allDone to AllDone
      if (Interlocked.CompareExchange(ref _allDone, NotDone, NotDone) == AllDone) {
        return; // if they did, then exit
      }
      ... loop to the top and carry on working
    }
    // main thread:
      Thread t1 = new Thread(() => GeneralSearchFunction(true));
      Thread t2 = new Thread(() => GeneralSearchFunction(false));
      t1.Start(); t2.Start(); // start both
      t1.Join(); t2.Join(); 
      // when this gets to here, one of them will have succeeded
