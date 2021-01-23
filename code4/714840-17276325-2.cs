    public static readonly DependencyProperty SelectedItemsExProperty =
        DependencyProperty.Register(
            "SelectedItemsEx", typeof(IEnumerable), typeof(MyListBox),
            new PropertyMetadata(SelectedItemsExPropertyChanged));
    public IEnumerable SelectedItemsEx
    {
        get { return (IEnumerable)GetValue(SelectedItemsExProperty); }
        set { SetValue(SelectedItemsExProperty, value); }
    }
    private static void SelectedItemsExPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var listBox = (MyListBox)obj;
        var oldCollectionChanged = e.OldValue as INotifyCollectionChanged;
        var newCollectionChanged = e.NewValue as INotifyCollectionChanged;
        if (oldCollectionChanged != null)
        {
            oldCollectionChanged.CollectionChanged -= listBox.SelectedItemsExCollectionChanged;
        }
        if (newCollectionChanged != null)
        {
            newCollectionChanged.CollectionChanged += listBox.SelectedItemsExCollectionChanged;
        }
    }
    private void SelectedItemsExCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            ...
        }
    }
