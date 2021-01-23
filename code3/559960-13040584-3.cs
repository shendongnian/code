     class LockWithCount : IDisposable
    {
        static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        object lockObj;
        public static long TotalWaitTicks = 0;
        public static long TotalBlocks = 0;
        static LockWithCount()
        {
            watch.Start();
        }
        public LockWithCount(object obj)
        {
            lockObj = obj;
            long startTicks = watch.ElapsedTicks;
            if (!System.Threading.Monitor.TryEnter(lockObj))
            {
                System.Threading.Interlocked.Increment(ref TotalBlocks);
                System.Threading.Monitor.Enter(lockObj);
                System.Threading.Interlocked.Add(ref TotalWaitTicks, watch.ElapsedTicks - startTicks);
            }
        }
        public void Dispose()
        {
            System.Threading.Monitor.Exit(lockObj);
        }
    }
