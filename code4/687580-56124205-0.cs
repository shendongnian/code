    List<ResultLine> result = Lines
        .GroupBy(l => l.ProductCode)
        .Select(cl => new Models.ResultLine
                {
                    ProductName = cl.select(x=>x.Name).FirstOrDefault(),
                    Quantity = cl.Count().ToString(),
                    Price = cl.Sum(c => c.Price).ToString(),
                }).ToList();
