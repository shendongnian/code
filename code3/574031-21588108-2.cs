    using System.Windows.Data;
    using System.ComponentModel;
    ICollectionView view = CollectionViewSource.GetDefaultView(grid.ItemsSource);
    if (view != null)
    {
        view.SortDescriptions.Clear();
        foreach (DataGridColumn column in grid.Columns)
        {
            column.SortDirection = null;
        }
    }
