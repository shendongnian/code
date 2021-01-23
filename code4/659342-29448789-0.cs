    public MyWindow()
    {
        InitializeComponent();
        (MyListview.View as GridView).Columns.CollectionChanged += ColumnsReordered;
    }
    private void PreventDrag(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            e.Handled = true;
    }
    private void ColumnsReordered(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Move)
        {
            var columns = sender as GridViewColumnCollection;
            if (columns != null)
                Dispatcher.BeginInvoke((Action)(() => columns.Move(columns.IndexOf(FirstColumn.Column), 0)));
        }
    }
