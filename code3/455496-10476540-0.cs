    //datagrid gotfocus event
    private void dataGrid1_GotFocus(object sender, RoutedEventArgs e)
    {
        DependencyObject dep = (DependencyObject)e.OriginalSource;
    
        // iteratively traverse the visual tree
        while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
        {
            dep = VisualTreeHelper.GetParent(dep);
        }
    
        if (dep == null)
            return;
    
        if (dep is DataGridCell)
        {
            DataGridCell cell = dep as DataGridCell;
            //raise key down event of cell
            cell.IsSelected = true;
            cell.KeyDown += new KeyEventHandler(cell_KeyDown);
        }
    }
    
    void cell_KeyDown(object sender, KeyEventArgs e)
    {
        DataGridCell cell = sender as DataGridCell;
        if (e.Key == Key.Enter)
        {
            cell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            cell.IsSelected = false;
            e.Handled = true;
            cell.KeyDown -= cell_KeyDown;
        }
    }
