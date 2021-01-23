    static Task<int> GetSuperLargeNumber()
    {
        var main = Task.Factory.StartNew(() =>
                                             {
                                                 Thread.Sleep(1000);
                                                 return 100;
                                             });
        var second = main.ContinueWith(
            x => Console.WriteLine("Second: " + x.Result),
            TaskContinuationOptions.AttachedToParent);
        var third = main.ContinueWith(
            x => Console.WriteLine("Third: " + x.Result),
            TaskContinuationOptions.AttachedToParent);
        return Task.Factory.ContinueWhenAll(
            new[] { second, third },
            (twotasks) => /* not sure how to get the original result here */);
        }
