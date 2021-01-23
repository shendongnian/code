    private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var gridView = sender as GridView;
        if (gridView == null) return;
        if (gridView.SelectedItems.Count > 2)
        {
            gridView.SelectedItems.Remove(gridView.SelectedItems[0]);
        }
    }
