    var output = new List<Product>();
    foreach (var p in SqlResult)
    {
        var products = p.Product.Split(',');
        output.AddRange(products.Select(product => new Product { SNo = p.SNo, ProductName = product, Cost = p.Cost }));
    }
