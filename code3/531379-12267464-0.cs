    var query = context.Products
                       .AsEnumerable() // Everything from here is LINQ to Objects
                       .Select(p => new {
                                   p.Price,
                                   PricePounds = Math.Truncate(p.Price)
                               });
