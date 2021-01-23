    private int CountConditions(TreeViewItem item)
    {
        int error = -1
        if (item.Tag.Equals("Condition")) 
        {
            return error;
        }
        else
        {
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
            return 1 + childCounts;
        }
    }
