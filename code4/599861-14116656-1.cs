    public interface IBudgetTrackerDataService
    {
      Task<IEnumerable<Category>> GetCategoriesAsync();
      Task<IEnumerable<Category>> GetCategoriesByParentAsync(string parent);
    }
    public Task<IEnumerable<Category>> GetCategoriesAsync()
    {
      // Let the HTTP client request the data
      return _client.GetAllCategories();
    }
    public Task<IEnumerable<Category>> GetCategoriesByParentAsync(string parent)
    {
      // Let the HTTP client request the data
      return _client.GetCategoriesWithParent(parent);
    }
