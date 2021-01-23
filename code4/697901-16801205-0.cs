    Context.Configuration.LazyLoadingEnabled = false;
    var buses = Context.Busses.Where(b => b.IsDriving)
                .Select(b => new 
                             { 
                                 b,
                                 Passengers = b.Passengers
                                               .Where(p => p.Awake)
                             })
                .ToList()
                .Select(x => x.b)
                .ToList();
