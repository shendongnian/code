    /// <summary>
    /// Get list of all categories except current one as well as all it's child categories
    /// </summary>
    /// <param name="id">Current category id</param>
    /// <param name="categories">List of categories</param>
    /// <returns>List of categories</returns>
    public static List<Category> CategoriesWithoutChildren(int id, List<Category> categories)
    {
    	var currentCategory = categories.Single(x => x.Id == id);
    	categories.Remove(currentCategory);
    
    	if (currentCategory.ChildCategories.Count > 0)
    	{
    		currentCategory.ChildCategories.ToList().ForEach(x =>
    		{
    			categories = CategoriesWithoutChildren(x.Id, categories);
    		});
    	}
    
    	return categories;
    }
