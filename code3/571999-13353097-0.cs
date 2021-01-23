    var products = from p in db.Products
                   group p by new {p.Code, p.Name} into g
                   select new Product
                   {
                       Code = g.Key.Code,
                       Name = g.Key.Name,
                       terms = g.Select(x => new Terms { 
                                                Term = x.Term, 
                                                Rate = x.Rate }).ToList()
                   };
