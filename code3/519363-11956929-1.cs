    public static void Main()
    {
        Random rnd = new Random();
        int maxValue = rnd.Next(20);
        /* Zip with Observable.Interval to introduce a delay */
        IObservable<int> mainEngine = Observable.Range(0, maxValue, Scheduler.NewThread)
            .Zip(Observable.Interval(TimeSpan.FromMilliseconds(100)), (a, b) => a);
        IConnectableObservable<int> published = mainEngine.Publish();
        /* Subscribe the first observer immediately, events are not yet being observed */
        published.Subscribe(onNext: (item) => { Console.WriteLine(item + " on observer 1"); });
        /* Start pushing events to the first observer */
        published.Connect();
        /* Wait one second and then subscribe the first observer */
        Thread.Sleep(1000);
        published.Subscribe(onNext: (item) => { Console.WriteLine(item + " on observer 2"); });
        Console.ReadKey();
    }
