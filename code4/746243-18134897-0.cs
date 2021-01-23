    static void A()
    {
        List<IAsyncResult> results = new List<IAsyncResult>();
        for (int i = 0; i < 10; i++)
        {
            results.Add(new Action(() =>
            {
                Thread.Sleep(1000);
            }).BeginInvoke(Callback, i));
        }
        foreach (var res in results)
        {
            res.AsyncWaitHandle.WaitOne();
        }
    } 
