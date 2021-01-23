    public CategoryBasedViewModel(IBudgetTrackerDataService budgetTrackerDataService)
    {
      _dataService = budgetTrackerDataService;
      CategoryCollection = new ObservableCollection<CategoryViewModel>();
      IsLoadingCategories = true;
      Initialized = InitializeAsync();
      NotifyOnInitializationErrorAsync();
    }
    private async Task InitializeAsync()
    {
      var categories = await _dataService.GetCategoriesAsync();
      CategoryCollection.Clear();
      foreach (var category in categories)
      {
        CategoryCollection.Add(new CategoryViewModel(category, _dataService));
      }
      // Wait until all CategoryViewModels have completed initializing.
      await Task.WhenAll(CategoryCollection.Select(category => category.Initialized));
      IsLoadingCategories = false;
    }
    private async Task NotifyOnInitializationErrorAsync()
    {
      try
      {
        await Initialized;
      }
      catch
      {
        NotifyPropertyChanged("InitializationError");
        throw;
      }
    }
    public string InitializationError { get { return Initialized.Exception.InnerException.Message; } }
