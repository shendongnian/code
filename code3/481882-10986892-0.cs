    Thread t = new Thread(LongProcess);
    t.Start();
    if (t.Join(10 * 1000) == false)
    {
        t.Abort();
    }
    //You are here in at most 10 seconds
    void LongProcess()
    {
        try
        {
            Console.WriteLine("Start");
            Thread.Sleep(60 * 1000);
            Console.WriteLine("End");
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("Aborted");
        }
    }
