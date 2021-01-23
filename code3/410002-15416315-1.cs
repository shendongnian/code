public class NamedLock {
    private class LockAndRefCounter
    {
        public int refCount { get; set; }
    }
    private ConcurrentDictionary<string, LockAndRefCounter> locksDictionary = new ConcurrentDictionary<string, LockAndRefCounter>();
    
        public void DoWithLockBy(string key, Action actionWithLock)
        {
            var lockObject = new LockAndRefCounter();
    
            var keyLock = locksDictionary.GetOrAdd(key, lockObject);
            lock (keyLock)
            {
                keyLock.refCount++;
                actionWithLock();
                
                keyLock.refCount--;
                if (keyLock.refCount <= 0)
                {
                    LockAndRefCounter removed;
                    locksDictionary.TryRemove(key, out removed);
                }
            }
        }
    }
