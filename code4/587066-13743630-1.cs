    var dicThreatPurgeSummary = new Dictionary<Tuple<int, int>, int>();
    dicThreatPurgeSummary.Add(new Tuple<int, int>(Group, Month), Count);
    // accessing the value
    int a = dicThreatPurgeSummary[new Tuple<int, int>(Group, Month)];
    // checking for existance
    if (dicThreatPurgeSummary.ContainsKey(new Tuple<int, int>(Group, Month)))
    {
        // ...
    }
