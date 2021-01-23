    IEnumerable<MenuItem> itemsToRemove = Items.Cast<object>().Where(mi => mi is MenuItem && ((MenuItem) mi).Tag == "Dynamic");
    foreach (MenuItem item in itemsToRemove)
    {
        Items.Remove(item);
    }
