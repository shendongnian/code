    /// <summary>
    /// Used to ensure only one call is made to the database at once 
    /// </summary>
    public class SingleAccessSynchroniser : IDisposable
    {
        public bool hasHandle = false;
        Mutex mutex;
        private void InitMutex()
        {
            string mutexId = "Global\\SingleAccessSynchroniser"; 
            mutex = new Mutex(false, mutexId);            
        }
        public SingleAccessSynchroniser() : this(0)
        { }
        public SingleAccessSynchroniser(int TimeOut)
        {
            InitMutex();
            
            if (TimeOut <= 0)
                hasHandle = mutex.WaitOne(); 
            else
                hasHandle = mutex.WaitOne(TimeOut);
            if (hasHandle == false)
                throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
        }
        public void Release()
        {
            if (hasHandle && mutex != null)
            {
                mutex.ReleaseMutex();
                hasHandle = false;
            }
        }
        public void Dispose()
        {
            Release();
        }
    }
