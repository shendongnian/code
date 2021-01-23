    var groupQuery = from r in Foundrows.AsEnumerable()
                     let time = TryParse(r.Field<string>("CallTime"))
                     where time.HasValue
                     group r by time.Value.Hours into g
                     select new {
                        Hrs = g.Key,
                        CallCount = g.Count()
                     };
