    public List<Product> FilterProducts(List<Category> categories)
    {
        var categoryIds = categories.Select(c => c.Id).ToArray();
        return products.Where(p => categoryIds
            .Any(c => p.Categories.Select(cat => cat.Id).Contains(c));
    }
