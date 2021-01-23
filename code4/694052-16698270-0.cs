    IEnumerable<Category> categories = db.Categories
        .Select(c => new
        {
            Category = c,
            FirstProduct = c.Products
                .OrderByDescending(p => p.Modified)
                .FirstOrDefault()
        })
        .AsEnumerable()
        .Select(x => x.Category);
