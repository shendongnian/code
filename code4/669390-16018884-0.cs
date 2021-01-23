    var results =
        (from c in db.Customers
         group c by c.Origin.OriginName into g
         let total = db.Customers.Count()
         select new
         {
             Origin = g.Key,
             Percent = ((double)g.Count() / (double)total) * 100
         })
        .ToList();
