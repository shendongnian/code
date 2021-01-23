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
    //consuming code:
    private static MyClassWithLockInside _instance = new MyClassWithLockInside();
    lock(_instance)
    {
        // doing something outside the class that takes a long time now has the effect
        // of blocking calls to MethodThatTakesLock even though it is unrelated, purely because
        // the choice of lock object accessible externally.
        Thread.Sleep(6000);
    }
