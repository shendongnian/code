    private void RadGridView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        var source = e.OriginalSource as DependencyObject;
        if(source == null)
            return;
    
        var cell = source.FindVisualParent<GridViewCell>();
        if(cell != null)
        {
            ((RadGridView)sender).SelectionUnit = GridViewSelectionUnit.Cell;
        }
        else
        {
            var row = source.FindVisualParent<GridViewRow>();
            if(row != null)
            {
                ((RadGridView)sender).SelectionUnit = GridViewSelectionUnit.FullRow;
            }
        }
    }
