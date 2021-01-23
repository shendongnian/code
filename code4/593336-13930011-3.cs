    private int CountConditions(TreeViewItem item)
    {
        int error = -1
        int childCounts = 0;
        foreach (TreeViewItem child in item.Items)
        {
            int childCount = CountConditions(child);
            if (childCount == error)
            {
                return error;
            }
            else
            {
                childCounts += childCount;
            }
        }
        if (item.Tag.Equals("Condition")) 
        {
            if (/* condition not satisfied */)
            {
                return error;
            }
            else
            {
                return 1 + childCounts
            }
        }
        else
        {
            return childCounts;
        }
    }
