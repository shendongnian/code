    class Robot : IDisposable {
        static private int nextId;
        static private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        static private IList<int> reuseIds = new List<int>();
        public int RobotId {get; private set;}
        Robot() {
            rwLock.EnterReadLock();
            try {
                if (reuseIds.Count == 0) {
                    RobotId = Interlocked.Increment(ref nextId);
                    return;
                }
            } finally {
                rwLock.ExitReadLock();
            }
            rwLock.EnterWriteLock();
            try {
                // Check the count again, because we've released and re-obtained the lock
                if (reuseIds.Count != 0) {
                    RobotId = reuseIds[0];
                    reuseIds.RemoveAt(0);
                    return;
                }
                RobotId = Interlocked.Increment(ref nextId);
            } finally {
                rwLock.ExitWriteLock();
            }
        }
        void Dispose() {
            rwLock.EnterWriteLock();
            reuseIds.Add(RobotId);
            rwLock.ExitWriteLock();
        }
    }
