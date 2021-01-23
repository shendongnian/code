    int error = -1
    private int CountConditions(TreeViewItem item)
    {
        int currentCondition = CalculateCondition(item)
        if (currentCondition == error) // new
            return error;              // new
        int childCounts = 0;
        foreach (TreeViewItem child in item.Items)
        {
            int childCount = CountConditions(child);
            if (childCount == error)   // new
                return error;          // new
            childCounts += childCount;
        }
        return currentCondition + conditionCounts
    }
    private int CalculateCondition(TreeViewItem item)
    {
        if (item.Tag.Equals("Condition"))
            if (((item.Header as StackPanel).Children[2] as TextBox).Text.Equals("")) // new
                return error; // new
            else              // new
                return 1;
        else
            return 0;
    }
