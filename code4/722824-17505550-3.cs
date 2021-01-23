    public List<Product> FilterProducts(List<Category> categories)
    {
        return products.Where(p => categories
            .Any(cat => p.Categories.Any(pcat => pcat.Id == cat.Id)).ToList();
    }
