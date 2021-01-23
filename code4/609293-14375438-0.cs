    static Task<int> GetSuperLargeNumber()
    {
        var main = Task.Factory.StartNew<int>(() =>
        {
            Thread.Sleep(1000);
            return 100;
        });
        var second = main.ContinueWith(x => Console.WriteLine("Second: " + x.Result), TaskContinuationOptions.AttachedToParent);
        var third = main.ContinueWith(x => Console.WriteLine("Third: " + x.Result), TaskContinuationOptions.AttachedToParent);
        Task.WaitAll(second, third);
        return main;
    }
