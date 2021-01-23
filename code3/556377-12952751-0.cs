    var bufferPeriod = TimeSpan.FromSeconds(1.5);
    var source = Observable.Interval(TimeSpan.FromMilliseconds(100)).Take(50);
    
    //source.Buffer(bufferPeriod).Dump();
    
    var bufferFlush = new Subject<long>();//Or Subject<Unit>
    source.Window(
            ()=>Observable.Merge(Observable.Timer(bufferPeriod), bufferFlush))
        .Select(window=>window.ToList())
        .Dump();
    
    //Simulate calling flush.
    Observable.Interval(TimeSpan.FromMilliseconds(1350)).Take(2).Subscribe(bufferFlush);
