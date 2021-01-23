    public List<Product> FilterProducts(List<Category> categories)
    {
        return products.Where(p => categories.Any(c => p.Categories.Contains(c)
                       .ToList();
    }
