    Context.Configuration.LazyLoadingEnabled = false;
    var bTemp = Context.Busses.Where(b => b.IsDriving)
                .Select(b => new 
                             { 
                                 b,
                                 Passengers = b.Passengers
                                               .Where(p => p.Awake)
                             })
                .ToList();
    foreach(x in bTemp)
    {
        x.b.Pasengers = x.Passengers;
    }
    var busses = bTemp.Select(x => x.b).ToList();
