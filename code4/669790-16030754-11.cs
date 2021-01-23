    var groupQuery = from r in Foundrows.AsEnumerable()
                     let time = r.Field<string>("CallTime").TryGetTimeSpan()
                     where time.HasValue
                     group r by time.Value.Hours into g
                     select new
                     {
                         Hrs = g.Key,
                         CallCount = g.Count()
                     };
