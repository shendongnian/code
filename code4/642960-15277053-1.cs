    void Main()
    {
        var rnd = new Random();
        var fakeSource = new Subject<Operation>();
        var producer = Observable
            .Interval(TimeSpan.FromMilliseconds(1000))
            .Subscribe(i => 
                {
                    var op = new Operation();
                    op.Type = rnd.NextDouble() < 0.5 ? "insert" : "delete";
                    fakeSource.OnNext(op);
                });    
        var singleSource = fakeSource.Publish().RefCount();
    
        var query = singleSource
            // We want to groupby until we see a change in the source
            .GroupByUntil(
                   i => i.Type, 
                   grp => singleSource.DistinctUntilChanged(op => op.Type))
            // then buffer up those observed events in the groupby window
            .Select(grp => grp.Buffer(TimeSpan.FromSeconds(8), 50));
    
        using(query.Subscribe(Console.WriteLine))
        {
            Console.ReadLine();
            producer.Dispose();        
        }
    }
    
    public class Operation { 
        private static int _cnt = 0;
        public Operation() { Seq = _cnt++; }
        public int Seq {get; set;}
        public string Type {get; set;}    
    }
