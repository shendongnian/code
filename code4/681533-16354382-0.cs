    var output = new List<ProductTable>();
    foreach (var p in SqlResult)
    {
        var products = p.Product.Split(',');
        output.AddRange(products.Select(product => new ProductTable { SNo = p.SNo, Product = product, Cost = p.Cost }));
    }
