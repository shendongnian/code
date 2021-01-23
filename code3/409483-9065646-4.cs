    DependencyObject dep = (DependencyObject)e.OriginalSource;
    while ((dep != null) && !(dep is DataGridColumnHeader))
    {
        dep = VisualTreeHelper.GetParent(dep);
    }
    if (dep == null) return;
    if (dep is DataGridColumnHeader)
    {
        MessageBox.Show(((DataGridColumnHeader)dep).Content.ToString());
    }
