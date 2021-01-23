    internal abstract class ClassA<TDerived>
    {
        private const Int32 MaximumNumberConcurrentThreads = 3;
        private static readonly Semaphore semaphore = new Semaphore(ClassA<TDerived>.MaximumNumberConcurrentThreads, ClassA<TDerived>.MaximumNumberConcurrentThreads);
        internal void MethodA()
        {
            try
            {
                ClassA<TDerived>.semaphore.WaitOne();
                this.MethodACore();
            }
            finally
            {
                ClassA<TDerived>.semaphore.Release();
            }
        }
        protected abstract void MethodACore();
    }
