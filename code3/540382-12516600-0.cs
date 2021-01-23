    var result = cars.GroupBy(c => c.Type)
                .Select(c => new {
                   Type = c.Key,
                   Options = c.SelectMany(x => x.Options)
                               .GroupBy(x => x.Name)
                               .Select(x => new {
                                      Option = x.Key ,
                                      Vins = c.Where(y => y.Options.Any(z => z.Name == x.Key)).Select(z => z.Vin)
                               })
                });
