    for (int i = 0; i < 100; i++)
    {
        ThreadPool.QueueUserWorkItem(s =>
        {
            Console.WriteLine("Output");
            Thread.Sleep(1000);
        });
    }
    CancellationTokenSource cts = new CancellationTokenSource();
    for (int i = 0; i < 100; i++)
    {
        ThreadPool.QueueUserWorkItem(s =>
        {
            CancellationToken token = (CancellationToken) s;
            if (token.IsCancellationRequested)
                return;
            Console.WriteLine("Output2");
            token.WaitHandle.WaitOne(1000);
        }, cts.Token);
    }
    cts.Cancel();
