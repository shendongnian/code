    private static bool isRun = false;
    private static readonly object syncLock = new object();
    public void MyMethod()
    {
        lock (syncLock)
        {
            if (!isRun)
            {
                Foo();            
                isRun = true;
            }
        }
    }
