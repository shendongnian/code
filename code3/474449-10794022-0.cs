    protected int numMeth1 = 0;
    protected Mutex mtxNumMeth1 = new Mutex();
    protected Mutex mtxExecutingMeth2 = new Mutex();
    protected Mutex mtxThereAreMeth1 = new Mutex();
 
    public void Method_1() 
    {
        // if this is the first execution of Method1, tells Method2 that it has to wait
        mtxNumMeth1.WaitOne();
        if (numMeth1 == 0)
            mtxThereAreMeth1.WaitOne();
        numMeth1++;
        mtxNumMeth1.ReleaseMutex();
        // check if Method2 is executing and release the Mutex immediately in order to avoid 
        // blocking other Method1's
        mtxExecutingMeth2.WaitOne();
        mtxExecutingMeth2.ReleaseMutex();
        // Do something that requires Prop_1 to be read
        // But *__do not__* lock Prop_1
        // if this is the last Method1 executing, tells Method2 that it can execute
        mtxNumMeth1.WaitOne();
        numMeth1--;
        if (numMeth1 == 0)
            mtxThereAreMeth1.ReleaseMutex();
        mtxNumMeth1.ReleaseMutex();
    } 
    public void Method_2() 
    {
        mtxThereAreMeth1.WaitOne();
        mtxExecutingMeth2.WaitOne();
        // Do something with Prop_1 *__only if__* Method_1 () is not currently executing
        mtxExecutingMeth2.ReleaseMutex();
        mtxThereAreMeth1.ReleaseMutex();
    } 
