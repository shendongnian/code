    public class MyClassWithLockInside
    {
        public void MethodThatTakesLock()
        {
            lock(this)
            {
                // do some work
            }
        }
     }
    public class Consumer
    {
        private static MyClassWithLockInside _instance = new MyClassWithLockInside();
        
        public void ThreadACallsThis()
        {
              lock(_instance)
              {
                  // Having taken a lock on our instance of MyClassWithLockInside,
                  // do something long running
                  Thread.Sleep(6000);
               }
        }
        public void ThreadBCallsThis()
        {
             // If thread B calls this while thread A is still inside the lock above,
             // this method will block as it tries to get a lock on the same object
             // ["this" inside the class = _instance outside]
             _instance.MethodThatTakesLock();
        }  
    }
