    task = Task.Factory.StartNew(() =>
    {
        while (true)
        {
            wtoken.Token.ThrowIfCancellationRequested();
            DoWork();
            Thread.Sleep(10000);
        }
    }, wtoken, TaskCreationOptions.LongRunning);
