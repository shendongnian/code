    private void myDataGridPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        DependencyObject dep = (DependencyObject)e.OriginalSource;
        while ((dep != null) && !(dep is DataGridColumnHeader))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
        if (dep == null)
            return;
        if (dep is DataGridColumnHeader)
        {
            DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
            ICollectionView view = CollectionViewSource.GetDefaultView((sender as DataGrid).ItemsSource);
            if (columnHeader.Content.Equals("Class") || columnHeader.Content.Equals("Student"))
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Class", ListSortDirection.Ascending));
                view.SortDescriptions.Add(new SortDescription("Student", ListSortDirection.Ascending));
            }
        }
    }
