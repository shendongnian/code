    private static void CollapseRecursive(TreeViewItem item)
    {
        // Collapse item if expanded.
        if (item.IsExpanded)
        {
            item.IsExpanded = false;
        }
    
        // If the item has sub items...
        if (item.Items.Count > 0)
        {
            // ... iterate them...
            foreach (TreeViewItem subItem in item.Items)
            {
                // ... and if they themselves have sub items...
                if (subItem.Items.Count > 0)
                {
                    // ... collapse the sub item and its sub items.
                    CollapseRecursive(subItem);
                }
            }
        }
    }
