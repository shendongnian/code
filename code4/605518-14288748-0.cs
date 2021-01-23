    void Main()
    {
        // ButtonPush returns IObservable<bool>
        var buttonPusher = ButtonPush();
        var pushTracker = 
            from pushOn in buttonPusher.Where(p => p).Timestamp()
            let tickWindow = Observable.Interval(TimeSpan.FromMilliseconds(500))
            from tick in tickWindow
                .TakeUntil(buttonPusher.Where(p => !p))
                .Timestamp()
                .Select(t => t.Timestamp)
            select tick;
            
        Console.WriteLine("Start: {0}", Observable.Return(true).Timestamp().First().Timestamp);
        var s = pushTracker
            .SubscribeOn(NewThreadScheduler.Default)
            .Subscribe(x => Console.WriteLine("tick:{0}", x));
    }
    
    IObservable<bool> ButtonPush()
    {
        var push = new BehaviorSubject<bool>(false);    
        var rnd = new Random();
        Task.Factory.StartNew(
            () => 
            {
                // "press button" after random # of seconds
                Thread.Sleep(rnd.Next(2, 5) * 1000);
                push.OnNext(true);
                // and stop after another random # of seconds
                Thread.Sleep(rnd.Next(3, 10) * 1000);
                push.OnNext(false);
            });
        return push;
    }
