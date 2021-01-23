    var allCars = _db.GetAllCars().Select(x => new Car {
        Name = x.Name,
        Tires = x.Tires
    }).ToList();
    var cars = allCars.Take(allCars.Count() - 1).Select(x => new Car
    {
        Name = x.Name + ", ",
        Tires = x.Tires
    }).Concat(new[] { new Car {
        Name = allCars.Last().Name,
        Tires = allCars.Last().Tires
    }});
