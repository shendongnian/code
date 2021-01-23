    // First, get the distinct list of items
    List<ItemBO> items = new List<ItemBO>();
    foreach ( var category in categories )
    {
        foreach ( var item in category.Items )
        {
            if ( !items.Contains(item) )
                items.Add(item);
        }
    }
    // Second, get the list of items that have the category.
    List<ItemBO> filteredItems = items
        .Where( i => i.ItemCategory.Equals(category) )
        .FirstOrDefault();
