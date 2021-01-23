    public interface IBudgetTrackerDataService
    {
      Task<IList<Category>> GetCategoriesAsync();
      Task<IList<Category>> GetCategoriesByParentAsync(string parent);
    }
    public async Task<IList<Category>> GetCategoriesAsync()
    {
      // Let the HTTP client request the data
      IEnumerable<Category> categoryEnumerable = await _client.GetAllCategories().ConfigureAwait(false);
      return categoryEnumerable.ToList();
    }
    public async Task<IList<Category>> GetCategoriesByParentAsync(string parent)
    {
      // Let the HTTP client request the data
      IEnumerable<Category> categoryEnumerable = await _client.GetCategoriesWithParent(parent).ConfigureAwait(false);
      return categoryEnumerable.ToList();
    }
