    var singleSource = source.Publish().RefCount();
    using(singleSource.Subscribe(x => Console.WriteLine("{0}", x)))
    {
        Thread.Sleep(delay * 3);
        using(singleSource.Subscribe(x => Console.WriteLine("Inner: {0}", x)))
        {
            Thread.Sleep(delay * 3);
        }
        Thread.Sleep(delay * 5);
    }
