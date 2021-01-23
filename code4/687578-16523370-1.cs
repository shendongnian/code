    var results = from line in Lines
                  group line by line.ProductCode into g
                  select new ResultLine {
                    ProductName = g.First().Name,
                    Price = g.Sum(_ => _.Price).ToString(),
                    Quantity = g.Count().ToString(),
                  };
