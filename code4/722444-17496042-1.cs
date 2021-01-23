    private void action(CancellationToken cancel)
    {
        int i;
        for (i = 0; i < 1000000; ++i)
        {
            if (cancel.IsCancellationRequested)
                break;
            Thread.Sleep(10); // Simulate work.
        }
        Console.WriteLine("action() reached " + i);
    }
