    public sealed class MyObject : IDisposable
    {
        static ExtDeviceDriver devDrv;
        private Mutex mut = new Mutex(false,myMutex);
    
        public MyObject()
        {
            mut.WaitOne();
            //Thread safe code here.
            devDrv = new ExtDeviceDriver();
        }
        public void Dispose() {
            mut.ReleaseMutex();
        }
    }
    
