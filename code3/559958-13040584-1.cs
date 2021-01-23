        class LockWithCount : IDisposable
        {
            static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            object lockObj;
            long startTicks = 0;
            public static long TotalWaitTicks = 0;
            public static long TotalBlocks = 0;
            static LockWithCount()
            {
                watch.Start();
            }
    
            public LockWithCount(object obj)
            {
                bool blocked = false;
                lockObj = obj;
                startTicks = watch.ElapsedTicks;
                while (!System.Threading.Monitor.TryEnter(lockObj))
                {
                    blocked = true;
                }
                if (blocked)
                    System.Threading.Interlocked.Increment(ref TotalBlocks);
                System.Threading.Interlocked.Add(ref TotalWaitTicks, watch.ElapsedTicks-startTicks);
            }
    
    
            public void Dispose()
            {
                System.Threading.Monitor.Exit(lockObj);
            }
        }
