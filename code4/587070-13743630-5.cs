    var dicThreatPurgeSummary = new IntIntDict<int>();
    dicThreatPurgeSummary.Add(Group, Month, Count);
    
    // accessing the value
    int a = dicThreatPurgeSummary[Group, Month];
    
    // checking for existance
    if (dicThreatPurgeSummary.ContainsKey(Group, Month))
    {
        // ...
}
