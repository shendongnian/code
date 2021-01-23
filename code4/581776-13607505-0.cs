    List<object> inserted = null; // Change null for all the elements in the table.
    IEnumerable<object> diff = newItems.Except(inserted); // Assume newItems is the list with new items.
    foreach(object elem in diff)
    {
        if (newItems.Contains(elem))
            // insert
        else
            // delete
    }
