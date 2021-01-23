    void MultiSelectListSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach(var item in e.AddedItems)
        {
            // add to collection
        }
        foreach(var item in e.RemovedItems)
        {
            // remove from collection
        }
    }
