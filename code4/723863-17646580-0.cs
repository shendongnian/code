    Cultures.SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
    void SelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        this.RaisePropertyChanged("TotalSelectedCultures");
    }
