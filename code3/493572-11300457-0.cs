    var singleGroup = groupedUsageData.ElementAt(0);
    string sessionId = singleGroup.Key.SessionId;
    string name = singleGroup.Key.Name;
    
    IEnumerable<string> accessedAppsNames = singleGroup.Select(x => x.PartOfAppAccessed.Name);
