    var toDelete = new HashSet<T>();
    foreach (var item in sortedItems)
    {
        if (!toDelete.Contains(item))
        {
            toDelete.Add(item);
            // do something with item here
        }
        foreach (var dependentFirst in item.DependentElements)
        {
            if (!toDelete.Contains(item))
            {
                toDelete.Add(dependentFirst);
                // do something with item here
            }
        }
    }
    sortedItems.RemoveAll(i => toDelete.Contains(i));
