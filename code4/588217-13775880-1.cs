    static IEnumerable<Category> GetById(IEnumerable<Category> categories, string id)
    {
        if (categories == null || !categories.Any())
            yield break;
    
        Category result = categories.FirstOrDefault(c => c.Id == id);
        if (result != null)
        {
            yield return result;
            yield break;
        }
    
        foreach (var category in categories)
        {
            var subCategories = GetById(category.Categories, id);
            if (subCategories.Any())
            {
                yield return category;
    
                foreach (var c in subCategories)                    
                    yield return c;                    
    
                yield break;
            }
        }
    }
