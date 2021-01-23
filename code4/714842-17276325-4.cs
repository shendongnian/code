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
        var oldColl = e.OldValue as INotifyCollectionChanged;
        var newColl = e.NewValue as INotifyCollectionChanged;
        if (oldColl != null)
        {
            oldColl.CollectionChanged -= listBox.SelectedItemsExCollectionChanged;
        }
        if (newColl != null)
        {
            newColl.CollectionChanged += listBox.SelectedItemsExCollectionChanged;
        }
    }
    private void SelectedItemsExCollectionChanged(
        object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            ...
        }
    }
