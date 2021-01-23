    public RangeObservableCollection<Item> AllItems
    { 
        get { return _allItems; }
        set 
        { 
            if (_allItems != null)
            { 
                _allItems.CollectionChanged -= AllItems_CollectionChanged;
            }
            _allItems = value; }
            if (_allItems != null)
            { 
                _allItems.CollectionChanged  +-= AllItems_CollectionChanged;
            }
    }
    private void AllItems_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        OnCollectionChanged(e);
    }
    
    private void OnCollectionChanged(CollectionChangedEventArgs args)
    {
        EventHandler<CollectionChangedEventArgs> temp = CollectionChanged;
        if (temp != null)
        {
            temp.Invoke(this, args);
        }
    }
