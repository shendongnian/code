    Dictionary<int, int> innerDic = null;
    bool isGroupPresent = dicThreatPurgeSummary.TryGetValue(Group, out innerDic);
    if(isGroupPresent == false)
    {
        //No entry for Group.
    }
    else
    {
        int count;
        bool isMonthPresent = innerDic.TryGetValue(Month, out count);
        //Same as above
    }
