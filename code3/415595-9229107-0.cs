    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        var dataItem = checkBox.DataContext as MyDataItem;
        var parentDataObject = myGridView.ItemsSource as SomeDataObject;
    
        if (dataItem == null || parentDataObject == null)
            return;
    
        var index = parentDataObject.SomeCollection.IndexOf(dataItem);
        // Do something with index
    }
