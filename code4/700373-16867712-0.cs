    public ICollectionView MyCollectionView { get; set; }
    public ViewModel()
    {
        var items = new List<string>
        {
            "Apple",
            "Orange"
        };
        MyCollectionView = CollectionViewSource.GetDefaultView(items);
        // Will only display items starting with "A".
        MyCollectionView.Filter = item => ((string)item).StartsWith("A");
    }
