    private int _totalValue;
    public int TotalValue
    {
        get { return _totalValue; }
        private set
        {
            if (value == _totalValue) return;
            _totalValue = value;
            OnPropertyChanged();
        }
    }
    private ObservableCollection<Category> _categories;
    public ObservableCollection<Category> Categories
    {
        get { return _categories; }
        set
        {
            if (Equals(value, _categories)) return;
            DetachHandlers(_categories); // not necessary if collection won't change after constructing ViewModel
            _categories = value;
            AttachHandlers(_categories); // could be only in constructor if collection won't cahnge later
            OnPropertyChanged();
        }
    }
    private void DetachHandlers(ObservableCollection<Category> categories)
    {
        // releases existing handlers
        if (categories == null)
        {
            return;
        }
        foreach (var category in categories)
        {
            category.PropertyChanged -= CategoryOnPropertyChanged;
        }
        categories.CollectionChanged -= CategoriesOnCollectionChanged;
    }
    private void AttachHandlers(ObservableCollection<Category> categories)
    {
        if (categories == null)
        {
            return;
        }
        foreach (var category in categories)
        {
            // crucial: triggers when slider values change
            category.PropertyChanged += CategoryOnPropertyChanged;
        }
        // necessary only if categories in the collection change later
        categories.CollectionChanged += CategoriesOnCollectionChanged;
    }
    private void CategoriesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
        // detach handlers from removed categories
        foreach (Category category in notifyCollectionChangedEventArgs.OldItems)
        {
            category.PropertyChanged -= CategoryOnPropertyChanged;
        }
        // attach handlers to added categories
        foreach (Category category in notifyCollectionChangedEventArgs.NewItems)
        {
            category.PropertyChanged += CategoryOnPropertyChanged;
        }
    }
    private void CategoryOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        if (propertyChangedEventArgs.PropertyName == "value")
        {
            // slider value changed: recalculate
            TotalValue = Categories.Sum(c => c.value);
        }
    }
