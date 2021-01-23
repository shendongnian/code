    private static object lockobj = new object();
    private volatile bool locked = false;
    public void DoWorkIfNotBusy()
    {
        if (!locked)
        {
            lock (lockobj)
            {
                if (!locked)
                {
                    locked = true;
                    // do work
                    Thread.Sleep(500);
                    Console.WriteLine("working...");
                }
                locked = false;
            }
        }
    }
