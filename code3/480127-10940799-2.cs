    foreach (Item item in draggedItems)
    {
        int oldIndex = collection.IndexOf(item.DataContext as MyItemType);
        int newIndex = Math.Min(toDropIndex, (collection.Count - 1));
        if (oldIndex == newIndex)
            continue;
        collection.Move(oldIndex, newIndex);
        if (oldIndex > newIndex)
            toDropIndex++;
    }
