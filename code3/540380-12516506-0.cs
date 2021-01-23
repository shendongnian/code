    var query = from c in cars
                group c by c.Type into g
                select new {
                  Type = g.key,
                  Options = from o in g.Options
                            select new {
                              o.Name,
                              Vins = from c in cars
                                     where c.Options.Any(x => x.Name == o.Name)
                                     where c.Type == g.Key
                                     select c.Vin
                            }
                }
 
