    private void DataGrid_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        DataGrid g = sender as DataGrid;
        if (g != null &&
            e.AddedItems.Count == 0 &&
            e.RemovedItems.Count > 0)
        {
            this.Dispatcher.BeginInvoke((ThreadStart)delegate
            {
                g.SelectedItem = (Device)e.RemovedItems[0];
            });
        }
    }
