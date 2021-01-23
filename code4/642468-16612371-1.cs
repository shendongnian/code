    var source = Observable.Range(1, 5);
    var query = source.SlidingWindow(3);
    using (query.Subscribe(i => Console.WriteLine(string.Join(",", i))))
    {
     
    }
