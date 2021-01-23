    public List<Product> FilterProducts(List<Category> categories)
    {
        return products.Where(p => categories.All(c => p.Categories.Contains(c))
                       .ToList();
    }
