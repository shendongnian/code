    private void DataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        var datagrid = sender as DataGrid;
        var view = CollectionViewSource.GetDefaultView(datagrid.ItemsSource) as CollectionView;
        if (view != null && view.Count > 0)
        {
            int firstIndex = (int)e.VerticalOffset;
            var firstItem = view.GetItemAt(firstIndex);
            int lastIndex = Math.Min(view.Count - 1, (int)(e.VerticalOffset + e.ViewportHeight));
            var lastItem = view.GetItemAt(lastIndex);
        }
    }
