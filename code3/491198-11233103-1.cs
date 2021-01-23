    public static void SetSortOrder(List<GroupInfo> groupInfos, GroupInfo target, int newSortOrder)
    {
        if (newSortOrder == target.SortOrder)
        {
            return; // No change
        }
        // If newSortOrder > SortOrder, shift all GroupInfos in that range down
        // Otherwise, shift them up
        int sortOrderAdjustment = (newSortOrder > target.SortOrder ? -1 : 1);
        // Get the range of SortOrders that must be updated
        int bottom = Math.Min(newSortOrder, target.SortOrder);
        int top = Math.Max(newSortOrder, target.SortOrder);
        // Get the GroupInfos that fall within our range
        var groupInfosToUpdate = from g in groupInfos
                                    where g.Id != target.Id
                                    && g.SortOrder >= bottom
                                    && g.SortOrder <= top
                                    select g;
        // Do the updates
        foreach (GroupInfo g in groupInfosToUpdate)
        {
            g.SortOrder += sortOrderAdjustment;
        }
    
        target.SortOrder = newSortOrder;
        // Uncomment this if you want the list to resort every time you update
        // one of its members (not a good idea if you're doing bulk changes)
        //groupInfos.Sort((info1, info2) => info1.SortOrder.CompareTo(info2.SortOrder));
    }
