    var typeCounts = new System.Collections.Concurrent.ConcurrentDictionary<String, Int32>();
    foreach (var c in UIList)
    {
        typeCounts.AddOrUpdate(c.GetType().FullName, 1, (typeName, count) => count + 1); 
    }
    int diffTypeCount = typeCounts.Count;
