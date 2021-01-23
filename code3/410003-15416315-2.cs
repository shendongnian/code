    public class NamedLock
    {
        private class LockAndRefCounter
        {
            public long refCount;
        }
    
        private ConcurrentDictionary<string, LockAndRefCounter> locksDictionary = new ConcurrentDictionary<string, LockAndRefCounter>();
    
        public void DoWithLockBy(string key, Action actionWithLock)
        {
            var lockObject = new LockAndRefCounter();
    
            var keyLock = locksDictionary.GetOrAdd(key, lockObject);
            Interlocked.Increment(ref keyLock.refCount);
    
            lock (keyLock)
            {
                actionWithLock();
    
                Interlocked.Decrement(ref keyLock.refCount);
                if (Interlocked.Read(ref keyLock.refCount) <= 0)
                {
                    LockAndRefCounter removed;
                    locksDictionary.TryRemove(key, out removed);
                }
            }
        }
    }
