    var groupQuery = from r in Foundrows.AsEnumerable()
                     let time = TimeSpan.Parse(r.Field<string>("CallTime"))
                     group r by time.Hours into g
                     select new {
                        Hrs = g.Key,
                        CallCount = g.Count()
                     };
