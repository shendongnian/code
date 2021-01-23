    MyObject myObject = new MyObject ();
    private static EventWaitHandle WaitHandle_m = new AutoResetEvent(false);
    public void FunA () // accessed from thread 1 (when user click a button)
    {   
        myObject = null;
        // do some stuff
        myObject = new MyObject ( someNewValues );
        WaitHandle_m.Set();
    }
    public void FunB () // accessed from thread 2 (calling using timer or smth.)
    {
        if (!WaitHandle_m.WaitOne(TimeSpan.FromMinutes(10)))
        {
            // whoops.
        }
        else
        {
            int x = myObject.ReadX ();
        }
    }
