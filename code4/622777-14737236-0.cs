    public class MutexChecker
    {
        private Mutex mutex;
        private const string instanceName = "AppName";
        private bool createdNew = false;
        public bool RunCheck()
        {            
            mutex = new Mutex(initiallyOwned: true, name: instanceName, createdNew: out createdNew);
            if (createdNew)
            {
                HelperClass.shutdown += Dispose;
            }
            else
            {
                MessageBox.Show("AppName is already running.  Please complete the other note before opening a new window.");
                mutex.Dispose();//dump...I don't need this instance
            }
            return createdNew;
        }
        void Dispose()
        {
            HelperClass.shutdown -= Dispose;
            mutex.Dispose();        
        }
    }
