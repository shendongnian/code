    products.ToList()
            .Where(p => p.CategoryId.HasValue)
            .Select(p => p.CategoryId.Value)
            .GroupBy(i => i)
            .ToDictionary(g => g.Key, g => g.Count());
