    class CustomSemaphore 
    {
        private static readonly object semaphoreLock = new object(); 
        private static readonly object[] resources = new[] { new object(), new object(), new object(), new object(), new object(), };
        public int AcquireLockObject() 
        { 
            lock (semaphoreLock)
            {
                for (int i = 0; i < 5; i++)
                { 
                    if (Monitor.TryEnter(resources[i]))
                        return i; 
                } 
            }
            return -1; // Lock unsuccessful.
        } 
        public void ReleaseLockObject(int lockIndex)
        {
            // Sanity check lockIndex range etc.
            lock (semaphoreLock)
            {
                Monitor.Exit(resources[lockIndex]);
            }
        } 
    }
