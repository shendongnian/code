    List<ResultLine> result = Lines
        .GroupBy(l => l.ProductCode)
        .Select(cl => new ResultLine
                {
                    ProductName = cl.First().Name,
                    Quantity = cl.Count().ToString(),
                    Price = cl.Sum(c => c.Price).ToString(),
                }).ToList();
