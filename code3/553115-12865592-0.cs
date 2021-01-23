    ...
    
    ObservableCollection<int> myCollection = new ObservableCollection<int>();
    myCollection.CollectionChanged += OnCollectionChanged;
    
    ...
    
    public void OnCollectionChanged( Object sender, NotifyCollectionChangedEventArgs e )
    {
       IsDirty = true;
    }
