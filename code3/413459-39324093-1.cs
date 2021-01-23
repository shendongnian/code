     from p in Products                         
      join bp in BaseProducts on p.BaseProductId equals bp.Id
      select new {
       p,
       bp
      } into t1
     group t1 by t1.p.SomeId into g
     select new ProductPriceMinMax { 
      SomeId = g.FirstOrDefault().p.SomeId, 
      CountryCode = g.FirstOrDefault().p.CountryCode, 
      MinPrice = g.Min(m => m.bp.Price), 
      MaxPrice = g.Max(m => m.bp.Price),
      BaseProductName = g.FirstOrDefault().bp.Name
    };
 
