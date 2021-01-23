    public static DataGrid FindDataGridAncestor(DependencyObject dependencyObject)
    {
            DependencyObject target = dependencyObject;
            do
            {
                target = VisualTreeHelper.GetParent(target);
            }
            while (target != null && !(target is DataGrid));
            return target as DataGrid;
    }
