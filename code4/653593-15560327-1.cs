    private static int Q;
    private static object qLock = new object();
    public void Inc()
    {
        lock(qLock)
        {
            qLock++;
        }
    }
