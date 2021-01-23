    var results = (from c in customers
                   select new 
                       {
                           Name = c.Name,
                           Products = c.ProductsPurchased.Where(p => ProductTypesToShow.Contains(p.ProductTypeId))
                       } into c2
                   where c2.Products.Any()
                   select new
                       {
                           Name = c2.Name,
                           Products = c2.Products.ToArray()
                       }).ToArray();
