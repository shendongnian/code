    // Declare this as a Generic method of Type T so that we can pass in a
    // List containing anything and easily get the appropriate Type object
    public static IEnumerable<T> SelectNonNull<T>(
        List<T> ListItems, string propertyName)
    {
        IEnumerable<T> itemsFromList;
        // Get a reference to the PropertyInfo for the property
        // we're doing a null-check on.
        PropertyInfo variable = typeof(T).GetProperty(propertyName);
        if (variable == null)
        {
            // The property does not exist on this item type:
            // just return all items
            itemsFromList = from item in ListItems
                            select item;
        }
        else
        {
            itemsFromList = from item in ListItems
                            // GetValue will check the value of item's
                            // instance of the specified property.
                            where variable.GetValue(item, null) != null
                            select item;
        }
        return itemsFromList;
    }
