    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(sender != null && sender is ListView)
        {
            if(e.AddedItems.Count > 0)
                (e.AddedItems[0] as MyDataOrDataVMClass).HasBeenRead = true;
        }
    }
