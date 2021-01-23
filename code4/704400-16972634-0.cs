    from p in trackingList
    group p by p.Value3 into g
    select new {
                   Value3 = g.Key,
                   DateIn = g.Where(o => o.Value4 == "IN")
                             .Select(o => o.Value1)
                             .DefaultIfEmpty(DateTime.MinValue)
                             .Min(),
                   DateOut = g.Where(o => o.Value4 == "OUT")
                              .Select(o => o.Value1)
                              .DefaultIfEmpty(DateTime.MaxValue)
                              .Max()
               }
