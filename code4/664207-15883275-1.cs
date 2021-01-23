    // Setup PropertyChange notification for each item in collection
    foreach(var item in MyCollection)
    {
        item.PropertyChanged += Item_PropertyChanged;
    }
    private bool _isSelectAllExecuting = false;
    // If the IsSelected property of an item changes, raise a property change 
    // notification for SelectAll
    void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (!_isSelectAllExecuting && e.PropertyName == "IsSelected") 
            ReevaluateSelectAll();
    }
    void ReevaluateSelectAll()
    {
        // Will evaluate true if no items are found that are not Selected
        _selectAll = MyCollection.FirstOrDefault(p => !p.IsSelected) == null;
        // Since we're setting private field instead of public one to avoid
        // executing command in setter, we need to manually raise the
        // PropertyChanged event to notify the UI it's been changed
        RaisePropertyChanged("SelectAll");
    }
    void SelectAll()
    {
        _isSelectAllExecuting = true;
        foreach(var item in MyCollection)
            item.IsSelected = true;
        _isSelectAllExecuting = false;
    }
