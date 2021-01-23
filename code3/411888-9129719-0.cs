    void MyCollection_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            for each (SomeObject item in e.NewItems)
                item.PropertyChanged += SomeObject_PropertyChanged;
        }
    
        if (e.OldItems != null)
        {
            for each (SomeObject item in e.OldItems)
                item.PropertyChanged -= SomeObject_PropertyChanged;
        }
    }
    
    void SomeObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // Handle event however you want here
    
        // For example, simply raise property change to refresh collection
        RaisePropertyChanged("MyCollection");
    
        // Or move item to new collection if it's selected
        if (e.Property == "IsSelected")
        {
            var item = object as SomeItem;
            MyCollectionA.Remove(item);
            MyCollectionB.Add(item);
        }
    }
