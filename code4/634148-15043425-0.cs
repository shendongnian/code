    static void Main()
    {
        Task.Factory.StartNew(() => { throw new Exception(); });
        // give the Task some time to run
        Thread.Sleep(100);
        GC.Collect();
    }
