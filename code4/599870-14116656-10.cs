    public CategoryViewModel(Category categoryModel, IBudgetTrackerDataService budgetTrackerDataService)
    {
      _category = categoryModel;
      _dataService = budgetTrackerDataService;
      // Retrieve all the child categories for this category
      Initialized = InitializeAsync();
    }
    private async Task InitializeAsync()
    {
      var categories = await _dataService.GetCategoriesByParentAsync(_category.RowKey);
      ...
    }
