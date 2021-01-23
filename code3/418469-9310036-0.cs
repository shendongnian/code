     public class Monitor
        {
            private Predicate<object> _filter;
            public Predicate<object> Filter
            {
                get { return _filter; }
                set 
                {
                    _filter = value;
                    ICollectionView collectionView = CollectionViewSource.GetDefaultView(test);
                    collectionView.Filter = new Predicate<object>(_filter);
                }
            }
            public ObservableCollection<Monitor> monitor{ get; set; }
    
                }
    public void Filter()
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(Monitors);
                collectionView.Filter = new Predicate<object>(FilterOutZero);
                foreach (var l in Monitors)
                {
                    l.Filter = collectionView.Filter;
    
                }
            }
