    using (var proxy = new YourServiceClient())
    {
        var t1 = proxy.GetMessagesAsync();
        var t2 = proxy.GetMessagesAsync();
        //they're runnning asynchronously now!
        //let's wait for the results:
        Task.WaitAll(t1, t2);
        var result1 = t1.Result;
        var result2 = t2.Result;
        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }
