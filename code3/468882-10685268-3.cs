    public ViewModelCtor()
    {
        Items = new List<...>();
        var collectionView = CollectionViewSource.GetDefaultView(Items);
        collectionView.CurrentChanged += (sender, args) => 
                       RaisePropertyChanged(() => CanDelete);
    }
    public bool CanDelete
    {
        get { return CollectionViewSource.GetDefaultView(Items).CurrentItem != null; }
    }
