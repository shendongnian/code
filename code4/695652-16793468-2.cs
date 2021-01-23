    var cardata = Repository.Data.Select(car => new { car.Id, car.Make }).Take(60).ToList();
    var carIds = cardata.Select(a => a.Id).ToList();
    foreach(var c in cardata)
    {
        var a = c;  // might be nessesary to prevent that only the last a is used for all queries
        a.Wheels = aRepository.Data.Where(c => c.Id == a.Id).SelectMany(car => car.Wheels).Select(w => new Wheel { Number = w.Number, Size = w.Size}).ToFuture();
    
        a.Foos = aRepository.Data.Where(c => c.Id == a.Id).SelectMany(car => car.Foos).Select(f => new Foo { Bar = f.Bar }).ToFuture();
    }
    
    cardata[0].Wheels.Any();  // execute the futures
    return cardata;
