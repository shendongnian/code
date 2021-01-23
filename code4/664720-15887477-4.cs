    public static readonly DependencyProperty SelectedItemsProperty =
        DependencyProperty.Register(
            "SelectedItems",
            typeof(ICollection),
            typeof(MultiSelectComboBox),
            new PropertyMetadata(SelectedItemsPropertyChanged));
    public ICollection SelectedItems
    {
        get { return (ICollection)GetValue(SelectedItemsProperty); }
        set { SetValue(SelectedItemsProperty, value); }
    }
    private static void SelectedItemsPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var comboBox = (MultiSelectComboBox)obj;
        var oldCollection = e.OldValue as INotifyCollectionChanged;
        var newCollection = e.NewValue as INotifyCollectionChanged;
        if (oldCollection != null)
        {
            oldCollection.CollectionChanged -= SelectedItemsCollectionChanged;
        }
        if (newCollection != null)
        {
            newCollection.CollectionChanged += SelectedItemsCollectionChanged;
        }
    }
    private static void SelectedItemsCollectionChanged(
        object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            ...
        }
    }
