    MyObject myObject = new MyObject ();
    Mutex mutex = new Mutex();
    
    public void FunA ()
    {
        mutex.WaitOne();
        myObject = null;
        // do some stuff
        myObject = new MyObject ( someNewValues );
        mutex.ReleaseMutex();
    }
    
    public void FunB ()
    {
        mutex.WaitOne();
        int x = myObject.ReadX ();
        mutex.ReleaseMutex();
    }
