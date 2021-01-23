    private void DataGrid_MouseRightButtonUp_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
        DependencyObject cell = VisualTreeHelper.GetParent(hit.VisualHit);
        while (cell != null && !(cell is System.Windows.Controls.DataGridCell)) cell = VisualTreeHelper.GetParent(cell);
        System.Windows.Controls.DataGridCell targetCell = cell as System.Windows.Controls.DataGridCell;
                
        // At this point targetCell should be the cell that was clicked or null if something went wrong.
    }
