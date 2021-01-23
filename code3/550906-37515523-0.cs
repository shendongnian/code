    public class Foo
    {
        private static ConcurrentDictionary<string, object> _lockDictionary = new ConcurrentDictionary<string, object>();
        public void DoSomethingThreadCriticalByString(string lockString)
        {
            object thisThreadSyncObject = new object();
            lock (thisThreadSyncObject)
            {
                try
                {
                    for (; ; )
                    {
                       object runningThreadSyncObject = _lockDictionary.GetOrAdd(lockString, thisThreadSyncObject);
                       if (runningThreadSyncObject == thisThreadSyncObject)
                           break;
                        lock (runningThreadSyncObject)
                        {
                            // Wait for the currently processing thread to finish and try inserting into the dictionary again.
                        }
                    }
                    // Do your work here.
                }
                finally
                {
                    // Remove the key from the lock dictionary
                    object dummy;
                    _lockDictionary.TryRemove(lockString, out dummy);
                }
            }
        }
    }
