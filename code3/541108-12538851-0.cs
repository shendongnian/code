    class Foo
    {
        static Mutex _mut(false);
        public MyObject()
        {
            _mut.WaitOne();
            //Thread safe code here.
            devDrv = new ExtDeviceDriver();
            _mut.ReleaseMutex();
        }
    
        public void SomeSynchronizedMethod()
        {
            // synchronize this call
            _mut.WaitOne();
            devDrv.DoSomething();
            _mut.ReleaseMutex();
        }
    }
