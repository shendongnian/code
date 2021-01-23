    int delay = 100;
    var source = Observable.Interval(TimeSpan.FromMilliseconds(delay));
    var publishingFrontend = new Subject<string>();
    
    // Here's "raw"
    var rawStream = source;
    using(rawStream.Subscribe(x => Console.WriteLine("{0}", x)))
    {
        Thread.Sleep(delay * 3);
        using(rawStream.Subscribe(x => Console.WriteLine("Inner: {0}", x)))
        {
            Thread.Sleep(delay * 3);
        }
        Thread.Sleep(delay * 5);
    }
