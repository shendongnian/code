    public IObservableCollection<ItemViewModel> Items
    {
        get { return _items; }
        set
        {
            // If required, initialize empty _items collection and attach
            // event handler
            if (_items == null) {
                _items = new BindableCollection<ItemViewModel>();
                _items.CollectionChanged += OnItemsCollectionChanged;
            }
            // Clear old contents in _items
            _items.Clear();
            // Add value item:s one by one to _items
            if (value != null) foreach (var item in value) _items.Add(item);
            NotifyOfPropertyChange(() => Items);
        }
    }
