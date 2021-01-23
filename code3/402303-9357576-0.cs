    // PreviewMouseDown event handler on the TabControl
    private void TabControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (IsUnderTabHeader(e.OriginalSource as DependencyObject))
            CommitTables(yourTabControl);
    }
    
    private bool IsUnderTabHeader(DependencyObject control)
    {
        if (control is TabItem)
            return true;
        DependencyObject parent = VisualTreeHelper.GetParent(control);
        if (parent == null)
            return false;
        return IsUnderTabHeader(parent);
    }
    
    private void CommitTables(DependencyObject control)
    {
        if (control is DataGrid)
        {
            DataGrid grid = control as DataGrid;
            grid.CommitEdit(DataGridEditingUnit.Row, true);
            return;
        }
        int childrenCount = VisualTreeHelper.GetChildrenCount(control);
        for (int childIndex = 0; childIndex < childrenCount; childIndex++)
            CommitTables(VisualTreeHelper.GetChild(control, childIndex));
    }
