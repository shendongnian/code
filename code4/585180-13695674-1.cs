    task = Task.Factory.StartNew(async () =>
    {
        while (true)
        {
            DoWork();
            await Task.Delay(10000, wtoken.Token);
        }
    }, wtoken.Token);
