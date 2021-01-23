    public void SetSortOrder(List<GroupInfo> groupInfos, int newSortOrder)
    {
        if (newSortOrder == SortOrder)
        {
            return; // No change
        }
        // If newSortOrder > SortOrder, shift all GroupInfos in that range down
        // Otherwise, shift them up
        int sortOrderAdjustment = (newSortOrder > SortOrder ? -1 : 1);
        // Get the range of SortOrders that must be updated
        int bottom = Math.Min(newSortOrder, SortOrder);
        int top = Math.Max(newSortOrder, SortOrder);
        // Get the GroupInfos that fall within our range
        var groupInfosToUpdate = from g in groupInfos
                                    where g.Id != this.Id
                                    && g.SortOrder >= bottom
                                    && g.SortOrder <= top
                                    select g;
        // Do the updates
        foreach (GroupInfo g in groupInfosToUpdate)
        {
            g.SortOrder += sortOrderAdjustment;
        }
    
        this.SortOrder = newSortOrder;
        // Uncomment this if you want the list to resort every time you update
        // one of its members
        //groupInfos.Sort((info1, info2) => info1.SortOrder.CompareTo(info2.SortOrder));
    }
