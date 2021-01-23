    var query = from car in Repository.Data
                from wheel in car.Wheels
                select new { car.Id, car.Make, wheel.Number, wheel.Size };
    
    var data = query
        .Take(60)
        .GroupBy(a => a.Id, (key, values) => new Allocation
        {
          Make = values.First().Make,
          Wheels = values.Select(a => new Wheel
              {
                  Number = a.Number,
                  Size = a.Size,
              })
              .ToArray(),
        })
        .ToArray();
