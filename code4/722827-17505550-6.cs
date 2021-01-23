    public List<Product> FilterProducts(List<Category> categories)
    {
         return products.Where(p => categories
            .All(c => p.Categories.Any(cat => cat.Id == c.Id)).ToList()
    }
