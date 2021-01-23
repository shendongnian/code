    private void workgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        object selectedItem = ((DataGrid)sender).SelectedItem;
        Type type = selectedItem.GetType(); 
        string name = (string)type.GetProperty("PersonName").GetValue(selectedItem, null);
        int amount = (int)type.GetProperty("Amount").GetValue(selectedItem, null);
        string place = (string)type.GetProperty("Place").GetValue(selectedItem, null);
    }
