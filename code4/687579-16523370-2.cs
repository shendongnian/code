    var results = from line in Lines
                  group line by line.ProductCode into g
                  select new ResultLine {
                    ProductName = g.First().Name,
                    Price = g.Sum(pc => pc.Price).ToString(),
                    Quantity = g.Count().ToString(),
                  };
