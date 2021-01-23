    var results =
        (from c in db.Customers
         from o in c.Origins
         group o by o.DisplayName into g
         let total = db.Customers.Sum(x => x.Origins.Count())
         select new
         {
             Origin = g.Key,
             Percent = ((double)g.Count() / (double)total) * 100
         })
        .ToList();
