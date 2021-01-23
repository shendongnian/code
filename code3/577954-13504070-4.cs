    private static object lockobj = new object();
    public void DoWorkWhenNotBusy()
    {
        lock (lockobj)
        {
            // do work
            Console.WriteLine("Working #1 (should always complete)...");
            Thread.Sleep(500);
        }
    }
