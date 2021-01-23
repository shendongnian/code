    private static object lockobj = new object();
    public void doWork()
    {
        lock (lockobj)
        {
            // do work
        }
    }
