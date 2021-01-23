    public ViewModelCtor()
    {
        Items = new List<...>();
        var collectionView = CollectionViewSource.GetDefaultView(Items);
        collectionView.CurrentChanged += (sender, args) => 
                       RaisePropertyChanged(() => CanDoSomething);
    }
    public bool CanDoSomething
    {
        get { return CollectionViewSource.GetDefaultView(Items).CurrentItem != null; }
    }
