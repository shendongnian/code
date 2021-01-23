    cars.SelectMany(c => c.Options.Select(o => new { Car = c, Option = o.Name }))
        .GroupBy(x => x.Car.Type)
        .Select(x => new
                     {
                         Type = x.Key,
                         Options = x.GroupBy(y => y.Option, y => y.Car.Vin)
                                    .Select(y => new { Option = y.Key,
                                                       Cars = y.ToList() } )
                     })
