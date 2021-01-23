    public partial class YourClass
    {
        private ManualResetEvent _serviceObjectWaitHandle = new ManualResetEvent(false);
        private dynamic _serviceObject;
        
        private void Store(dynamic serviceObject)
        {
            _serviceObject = serviceObject;
            //If you need to do some work as soon as _serviceObject is ready...
            // then it can be done here, this may still be the thread pool thread.
            //If you need to call something like the UI...
            // you will need to use BeginInvoke or a similar solution.
            _serviceObjectWaitHandle.Set();
        }
        public void WaitForServiceObject()
        {
                //You may also expose other overloads, just for convenience.
                //This will wait until Store is executed
                //When _serviceObjectWaitHandle.Set() is called
                // this will let other threads pass.
                _serviceObjectWaitHandle.WaitOne();
        }
        public dynamic ServiceObject
        {
            get
            {
                return _serviceObject;
            }
        }
    }
