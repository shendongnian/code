    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                DataGrid g = sender as DataGrid;
    
                if (g != null &&
                    e.AddedItems.Count == 0 &&
                    e.RemovedItems.Count > 0)
                {
                    g.SelectedItem = e.RemovedItems[0];
                }
            }
