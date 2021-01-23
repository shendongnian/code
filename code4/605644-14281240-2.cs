    internal abstract class ClassA<TDerived> : ClassA
    {
        private const Int32 MaximumNumberConcurrentThreads = 3;
        private static readonly Semaphore semaphore = new Semaphore(ClassA<TDerived>.MaximumNumberConcurrentThreads, ClassA<TDerived>.MaximumNumberConcurrentThreads);
        internal void MethodA()
        {
            lock (ClassA.setCurrentlyExcutingTypeLock)
            {
                while (!((ClassA.currentlyExcutingType == null) || (ClassA.currentlyExcutingType == typeof(TDerived))))
                {
                    Monitor.Wait(ClassA.setCurrentlyExcutingTypeLock);
                }
                ClassA.numberCurrentlyPossiblyExecutingThread++;
                if (ClassA.currentlyExcutingType == null)
                {
                    ClassA.currentlyExcutingType = typeof(TDerived);
                }
                Monitor.PulseAll(ClassA.setCurrentlyExcutingTypeLock);
            }
            try
            {
                ClassA<TDerived>.semaphore.WaitOne();
                this.MethodACore();
            }
            finally
            {
                ClassA<TDerived>.semaphore.Release();
            }
            lock (ClassA.setCurrentlyExcutingTypeLock)
            {
                ClassA.numberCurrentlyPossiblyExecutingThread--;
                if (ClassA.numberCurrentlyPossiblyExecutingThread == 0)
                {
                    ClassA.currentlyExcutingType = null;
                    Monitor.Pulse(ClassA.setCurrentlyExcutingTypeLock);
                }
            }
        }
        protected abstract void MethodACore();
    }
