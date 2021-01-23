    [Fact]
    public void StartAndCancel()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var token = cancellationTokenSource.Token;
        var tasks = Enumerable.Repeat(0, 2)
                              .Select(i => Task.Run(() => Dial(token), token))
                              .ToArray(); // start dialing on two threads
        Thread.Sleep(200); // give the tasks time to start
        cancellationTokenSource.Cancel();
        Assert.Throws<AggregateException>(() => Task.WaitAll(tasks));
        Assert.True(tasks.All(t => t.Status == TaskStatus.Canceled));
    }
    public void Dial(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine("Called from thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(50);
        }
    }
