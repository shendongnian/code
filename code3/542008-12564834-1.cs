    var lockObj = new object();
    var myObject = new MyObject();
    public void FunA () // accessed from thread 1 (when user click a button)
    {
      lock(lockObj)
        {
           myObject = null;
           // do some stuff
           myObject = new MyObject ( someNewValues );
        }
    }
    public void FunB () // accessed from thread 2 (calling using timer or smth.)
    {
        lock(lockObj)
        {
           int x = myObject.ReadX ();
        }
    }
