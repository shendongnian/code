    private static object lockobj2 = new object();
    private volatile bool locked = false;
    public void DoWorkIfNotBusy()
    {
        if (!locked)
        {
            lock (lockobj2)
            {
                if (!locked)
                {
                    locked = true;
                    // do work
                    Thread.Sleep(500);
                    Console.WriteLine("Working #2 (only if not busy)...");
                }
                locked = false;
            }
        }
    }
