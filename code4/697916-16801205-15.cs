    Context.Configuration.LazyLoadingEnabled = false;
    // Or: Context.Configuration.ProxyCreationEnabled = false;
    var buses = Context.Busses.Where(b => b.IsDriving)
                .Select(b => new 
                             { 
                                 b,
                                 Passengers = b.Passengers
                                               .Where(p => p.Awake)
                             })
                .AsEnumerable()
                .Select(x => x.b)
                .ToList();
