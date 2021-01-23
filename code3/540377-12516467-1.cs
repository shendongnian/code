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
                                                               .Select(x => x.Name)
                                                               .Contains(o))
                                          })
                                .ToLookup(x => x.Option, x => x.Cars);
                });
