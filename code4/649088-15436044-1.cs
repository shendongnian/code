    public List<CategoryViewModel> GetAllCategories()
    {
        using (var db =new Entities())
        {
            var categoriesList = db .Categories
                .Select(c => new CategoryViewModel()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name,
                    CategoryDescription = c.Description
                });
            return categoriesList.ToList<CategoryViewModel>();
        };
     }
