    private int CountConditions(TreeViewItem item)
    {
        int currentCondition = CalculateCondition(item)
        int childCounts = 0;
        foreach (TreeViewItem child in item.Items)
        {
            int childCount = CountConditions(child);
            childCounts += childCount;
        }
        return currentCondition + conditionCounts
    }
    private int CalculateCondition(TreeViewItem item)
    {
        if (item.Tag.Equals("Condition"))
            return 1;
        else
            return 0;
    }        
