    DependencyObject dep = (DependencyObject)e.OriginalSource;
 
    // iteratively traverse the visual tree
    while ((dep != null) &amp;&amp;
            !(dep is DataGridCell) &amp;&amp;
            !(dep is DataGridColumnHeader))
    {
        dep = VisualTreeHelper.GetParent(dep);
    }
 
    if (dep == null)
        return;
 
    if (dep is DataGridColumnHeader)
    {
        DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
        // do something
    }
 
    if (dep is DataGridCell)
    {
        DataGridCell cell = dep as DataGridCell;
        // do something
    }
