    var observable = Worker.GetObservable(); //Actually a Subject<string>
    Action<string> log = x => Console.Write("\r" + x);
    string latest = "";
    using(observable.Subscribe(x => latest = x))
    using(observable.Sample(TimeSpan.FromMilliseconds(100)).Subscribe(log))
    {
        Worker.DoWorkWithLogs();
        log(latest);
    }
    Console.WriteLine(" ...done.");
