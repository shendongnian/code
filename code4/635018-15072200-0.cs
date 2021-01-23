    List<TreeItem> orphanedItems = new List<TreeItem>();
    foreach (TreeItem item in results)
    {
        if (item.ParentTreeItemID != Guid.Empty &&
            !results.Contains(tree -> tree.ID == item.ParentTreeItemID)
        {
            orphanedItems.Add(item);
        }
    }
    foreach (TreeItem orphan in orphanedItems)
        results.Remove(orphan);
