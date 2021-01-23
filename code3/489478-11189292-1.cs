    // Loaded event handler for Datagrid
    private void DataGridLoaded(object sender, RoutedEventArgs e)
    {
        datagrid2.LayoutUpdated += DataGridLayoutUpdated;
    }
    private void DataGridLayoutUpdated(object sender, EventArgs e)
    {
        // Find the selectAll button present in grid
        DependencyObject dep = sender as DependencyObject;
        // Navigate down the visual tree to the button
        while (!(dep is Button))
        {
            dep = VisualTreeHelper.GetChild(dep, 0);
        }
        Button selectAllButton = dep as Button;
        // Create & attach a RowHeaderWidth binding to selectAllButton; 
        // used for resizing the first(header) column
        Binding keyBinding = new Binding("RowHeaderWidth");
        keyBinding.Source = this;
        keyBinding.Mode = BindingMode.OneWay;
        selectAllButton.SetBinding(WidthProperty, keyBinding);
        // We don't need to do it again, Remove the handler
        LayoutUpdated -= HandleMatrixDataGridLayoutUpdated;
    }
