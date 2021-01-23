    query = (from prod in myProducts
      group prod by new {Month = prod.lossDate.ToString("yyyy-MM"), prod.lossCode} into g
      select new
      {
         g.Key.Month,                   
         ReasonCode = g.Key.lossCode,
         NumLosses = g.Count()
      }
    ).OrderByDescending(x => c.NumLosses)
