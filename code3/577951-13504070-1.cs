    private static object lockobj = new object();
    public void DoWorkWhenNotBusy()
    {
        lock (lockobj)
        {
            // do work
            Console.WriteLine("Working...");
            Thread.Sleep(500);
        }
    }
