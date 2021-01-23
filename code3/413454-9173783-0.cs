    var result = from p in Products                         
     group p by p.SomeId into pg                         
     // join *after* group
     join bp in BaseProducts on pg.FirstOrDefault().BaseProductId equals bp.Id         
     select new ProductPriceMinMax { 
           SomeId = pg.FirstOrDefault().SomeId, 
           CountryCode = pg.FirstOrDefault().CountryCode, 
           MinPrice = pg.Min(m => m.Price), 
           MaxPrice = pg.Max(m => m.Price),
           BaseProductName = bp.Name  // now there is a 'bp' in scope
     };
