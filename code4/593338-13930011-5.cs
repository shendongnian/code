    int error = -1
    private int CountConditions(TreeViewItem item)
    {
        int currentCondition = CalculateCondition(item)
        if (currentCondition == error)
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
            return currentCondition + conditionCounts
        }
    }
    private int CalculateCondition(TreeViewItem item)
    {
        if (item.Tag.Equals("Condition"))
        {
            StackPanel spCurrent = item.Header as StackPanel;
            if ((spCurrent.Children[2] as TextBox).Text.Equals(""))
            {
                return error;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }        
