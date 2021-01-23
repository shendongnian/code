    Console.WriteLine("Simulated Publish:");
    // use a subject to proxy values...
    var innerSubject = new Subject<long>();
    // wire up the source to "write to" the subject
    var innerSub = source.Subscribe(innerSubject);
    var simulatedSingleSource = Observable.Create<long>(obs =>
    {
        // return subscriptions to the "proxied" subject
        var publishPoint = innerSubject.Subscribe(obs);        
        return publishPoint;
    });
