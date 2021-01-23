    // Be warned that the `Loaded` event runs anytime the window loads into view,
    // so you will probably want to include an Unloaded event that detaches the
    // collection
    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        var dg = (DataGrid)sender;
        if (dg == null || dg.ItemsSource == null) return;
        var sourceCollection = dg.ItemsSource as ObservableCollection<ViewModelBase>;
        if (sourceCollection == null) return;
        sourceCollection .CollectionChanged += 
            new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
    }
    void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Execute your logic here
    }
