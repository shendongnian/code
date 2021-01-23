    var source = new Subject<Pair>();
    // The Publish().RefCount() and Subscribe() are to make the sequence hot
    var changedSender = source.DistinctUntilChanged(p => p.Sender).Publish().RefCount();
    changedSender.Subscribe();
    var throttled = source.Select(p =>
        Observable.Amb(changedSender, source.Skip(TimeSpan.FromMilliseconds(300))).Take(1))
        .Concat();
    throttled.Subscribe(WritePair);
    source.OnNext(new Pair("A", "i"));
    System.Threading.Thread.Sleep(10);
    source.OnNext(new Pair("A", "it"));
    System.Threading.Thread.Sleep(10);
    source.OnNext(new Pair("A", "bit"));
    System.Threading.Thread.Sleep(500);
    source.OnNext(new Pair("A", "bite"));
    source.OnNext(new Pair("B", "a"));
    System.Threading.Thread.Sleep(10);
    source.OnNext(new Pair("A", "bitey"));
    System.Threading.Thread.Sleep(500);
    source.OnNext(new Pair("A", "at"));
