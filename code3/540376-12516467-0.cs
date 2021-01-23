    cars.GroupBy(x => x.Type)
        .Select(cs =>
                {
                    var options = cs.SelectMany(c => c.Options)
                                    .Select(o => o.Name)
                                    .Distinct();
                    return options.Select(o => new 
                                          {
                                              Option = o,
                                              Cars =
                                                cs.Where(c => c.Options
                                                               .Contains(co =>
                                                                    co.Name == o))
                                          })
                                .ToLookup(x => x.Option, x => x.Cars)
                }
