    var model = db
        .Categories
        .Select(c => new MyViewModel
        {
            Name = c.Name,
            ProductsCount = c.Products.Count()
        })
        .ToList();
