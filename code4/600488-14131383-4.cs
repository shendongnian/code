    private static void Main(string[] args)
    {
        var sync = new object();
        var foo = Observable.CreateWithDisposable<long>(obs =>
        {
            Log("Subscribing starting.. this will take a few seconds..");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var sub = Observable.Interval(TimeSpan.FromSeconds(1))
                            .Do(_ => Log("I am polling..."))
                            .Synchronize(sync)
                            .Subscribe(obs);
            return Disposable.Create(
                () =>
                    {
                        lock (sync)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                            sub.Dispose();
                            Log("Disposing is really done now!");                                
                        }
                    });
        });
    
        Log("I am subscribing..");
        var disp = foo
            .SubscribeOn(Scheduler.NewThread)
            .Subscribe(i => Log("Processing " + i));
    
        Log("I have returned from subscribing...");
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Log("I'm going to dispose...");
        disp.Dispose();
        Log("Disposed has returned...");
        Console.ReadKey();
    }
