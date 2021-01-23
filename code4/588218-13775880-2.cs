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
            if (subCategories.Any()) // we have found the category
            {
                yield return category; // return current category first
    
                foreach (var subCategory in subCategories)                    
                    yield return subCategory;                   
    
                yield break; // don't search in other categories
            }
        }
    }
