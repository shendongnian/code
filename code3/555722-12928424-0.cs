    private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
            var dep = e.OriginalSource as DependencyObject;
            //go up the tree until you find the header
            while (dep != null && !(dep is DataGridRowHeader)) {
                dep = VisualTreeHelper.GetParent(dep);
            }
            //header found
            if (dep is DataGridRowHeader)
                //do this
            else //header not found
                //do that
    }
