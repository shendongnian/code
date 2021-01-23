    private int CountConditions(TreeViewItem item)
    {
        int childCounts = 0;
        foreach (TreeViewItem child in item.Items)
        {
            int childCount = CountConditions(child);
            childCounts += childCount;
        }
        if (item.Tag.Equals("Condition"))
        {
            1 + childCounts;
        }
        else
        {
            return childCounts;
        }
    }
