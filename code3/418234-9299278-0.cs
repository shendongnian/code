    // Assuming the allLocks class member is defined as follows:
    private static AutoResetEvent[] allLocks = new AutoResetEvent[10];
    // And initialized thus (in a static constructor):
    for (int i = 0; i < 10; i++) {
        allLocks[i] = new AutoResetEvent(true);
    }
    // Your method becomes
    var lockIndex = id % allLocks.Length;
    var lockToUse = allLocks[lockIndex];0
    // Wait for the lock to become free
    lockToUse.WaitOne();
    try {
        // At this point we have taken the lock
        // Do the work
    } finally {
        lockToUse.Set();
    }
