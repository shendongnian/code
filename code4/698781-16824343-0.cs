    private void Context_Delete(object sender, RoutedEventArgs e)
    {
        //Get the clicked MenuItem
        var menuItem = (MenuItem)sender;
        //Get the ContextMenu to which the menuItem belongs
        var contextMenu = (ContextMenu)menuItem.Parent;
        //Find the placementTarget
        var item = (DataGrid)contextMenu.PlacementTarget;
        //Get the underlying item, that you cast to your object that is bound
        //to the DataGrid (and has subject and state as property)
        var toDeleteFromBindedList = (YourObject)item.SelectedCells[0].Item;
        //Remove the toDeleteFromBindedList object from your ObservableCollection
        yourObservableCollection.Remove(toDeleteFromBindedList);
    }
