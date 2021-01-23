    public static readonly DependencyProperty ColumnsProperty =
        DependencyProperty.Register(
            "Columns", typeof(IEnumerable<string>), typeof(MyControl),
            new PropertyMetadata(null, ColumnsPropertyChanged));
    public IEnumerable<string> Columns
    {
        get { return (IEnumerable<string>)GetValue(ColumnsProperty); }
        set { SetValue(ColumnsProperty, value); }
    }
    private static void ColumnsPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var control= (MyControl)obj;
        var oldCollection = e.OldValue as INotifyCollectionChanged;
        var newCollection = e.NewValue as INotifyCollectionChanged;
        if (oldCollection != null)
        {
            oldCollection.CollectionChanged -= control.ColumnsCollectionChanged;
        }
        if (newCollection != null)
        {
            newCollection.CollectionChanged += control.ColumnsCollectionChanged;
        }
        control.UpdateColumns();
    }
    private void ColumnsCollectionChanged(
        object sender, NotifyCollectionChangedEventArgs e)
    {
        UpdateColumns();
    }
    private void UpdateColumns()
    {
        ...
    }
