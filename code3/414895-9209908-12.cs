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
    var instance = new MyClassWithLockInside();
    lock(instance)
    {
        // this call blocks forever, as it is locking against the same object as the "this" inside the class.
        instance.MethodThatTakesLock();
    }
