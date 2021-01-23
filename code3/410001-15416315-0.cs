    public class NamedLock
    {
        private ConcurrentDictionary<string, object> locksDictionary = new ConcurrentDictionary<string, object>();
    
        public void DoWithLockBy(string key, Action actionWithLock)
        {
            var lockObject = new object();
    
            var keyLock = locksDictionary.GetOrAdd(key, lockObject);
    
            lock (keyLock)
            {
                actionWithLock();
    
                object removed;
                locksDictionary.TryRemove(key, out removed);
            }
        }
    }
