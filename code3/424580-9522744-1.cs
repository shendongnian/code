    using (var db = new TestDataContext())
    {
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<Product>(p => p.ProductsInCategories);
        options.LoadWith<ProductsInCategory>(pic => pic.Category);
        db.LoadOptions = options;
        var filter = "product";
        var pageIndex = 1;
        var pageSize = 10;
        var query = db.Products
            .OrderBy(p => p.SortOrder)
            .ThenBy(p => p.Name)
            .Where(p => p.Name.Contains(filter) || p.Description.Contains(filter))
            .Select(p => p.ProductId);
        var total = query.Count();
        var products = db.Products
            .Where(p => query.Skip(pageIndex * pageSize).Take(pageSize).Contains(p.ProductId))
            .ToList();
    }
