    void Main()
    {
        var rnd = new Random();
        var fakeSource = new Subject<int>();
        var producer = Observable
            .Interval(TimeSpan.FromSeconds(2))
            .Subscribe(i => 
                {
                    var next = rnd.NextDouble() < 0.5 ? 1 : 2;
                    Console.WriteLine("Publishing {0}", next);
                    fakeSource.OnNext(next);
                });    
        var singleSource = fakeSource.Publish().RefCount();
        
        var query = singleSource
            // We want to groupby until we see a change in the source
            .GroupByUntil(i => i, grp=> singleSource.DistinctUntilChanged())
            // then buffer up those observed events in the groupby window
            .Select(grp => grp.Buffer(TimeSpan.FromSeconds(8), 50));
        
        using(query.Subscribe(Console.WriteLine))
        {
            Console.ReadLine();
        }
    }
