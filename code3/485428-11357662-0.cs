    /// <summary>
    /// Used to ensure only one instance (foreground app or background app) runs at once
    /// </summary>
    public class SingleInstanceSynchroniser : IDisposable
    {
        private bool hasHandle = false;
        Mutex mutex;
        private void InitMutex()
        {
            string mutexId = "Global\\SingleInstanceSynchroniser"; 
            mutex = new Mutex(false, mutexId);
        }
        public SingleInstanceSynchroniser()
        {
            InitMutex();
            hasHandle = mutex.WaitOne(0);
        }
        public void Dispose()
        {
            if (hasHandle && mutex != null)
                mutex.ReleaseMutex();
        }
        public bool HasExclusiveHandle { get { return hasHandle; } }
    }
