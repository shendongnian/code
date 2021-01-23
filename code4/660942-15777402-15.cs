    Console.WriteLine("MulticastPublish:");
    var multicastPublish = source.Multicast(new Subject<long>()).RefCount();    
    using(multicastPublish.Subscribe(x => Console.WriteLine("{0}", x)))
    {
        Thread.Sleep(delay * 3);
        using(multicastPublish.Subscribe(x => Console.WriteLine("Inner: {0}", x)))
        {
            Thread.Sleep(delay * 3);
        }
        Thread.Sleep(delay * 5);
    }
