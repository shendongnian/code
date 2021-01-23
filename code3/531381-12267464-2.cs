    var query = context.Products
                       .Select(p => new { p.Price, p.SomethingElse })
                       .AsEnumerable() // Everything from here is LINQ to Objects
                       .Select(p => new {
                                   p.Price,
                                   PricePounds = Math.Truncate(p.Price),
                                   p.SomethingElse
                               });
