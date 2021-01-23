    foreach (Item item in draggedItems)
    {
        int oldIndex = collection.IndexOf(item.DataContext as MyItemType);
        int newIndex = Math.Max(toDropIndex++, (collection.Count - 1));
        if (oldIndex != newIndex)
        {
            collection.Move(oldIndex, newIndex);
        }
    }
