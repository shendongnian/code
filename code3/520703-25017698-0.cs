    private void Sorting(IEnumerable collection)
    {
        var view = CollectionViewSource.GetDefaultView(collection) as ListCollectionView;
        if (view != null)
        {
            view.CustomSort = new StableComparer(collection);
        }
    }
