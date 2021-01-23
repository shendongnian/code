    private void MyList_SelectionChanged(object sender, 
        System.Windows.Controls.SelectionChangedEventArgs e)
    {
        // Find out which item was clicked
        if (e.AddedItems.Count > 0)
        {
            var myGuid = e.AddedItems[0] as Guid;
            if (myGuid == null)
                return;
            // ...
        }
    }
