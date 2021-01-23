    var cardata = Repository.Data.Select(car => new { car.Id, car.Make }).Take(60).ToList();
    foreach(var c in cardata)
    {
        var carId = c.Id;
        a.Wheels = aRepository.Data.Where(c => c.Id == carId).SelectMany(car => car.Wheels).Select(w => new Wheel { Number = w.Number, Size = w.Size}).ToFuture();
    
        a.Foos = aRepository.Data.Where(c => c.Id == carId).SelectMany(car => car.Foos).Select(f => new Foo { Bar = f.Bar }).ToFuture();
    }
    
    cardata[0].Wheels.Any();  // execute the futures
    return cardata;
