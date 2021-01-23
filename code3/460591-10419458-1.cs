    void Foo()
    {
        ObservableCollection<string> r = new ObservableCollection<string>();
        r.CollectionChanged += r_CollectionChanged;
    }
    static void r_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        var itemRemovedAtIndex = e.OldStartingIndex;
    }
