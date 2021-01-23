    var groups = new Dictionary<Type, IEnumerable<UserControl>>();
    foreach(var group in hashSet.GroupBy(x => x.GetType()))
        groups.Add(group.Key, group);
        .
        .
        .
    if (groups.ContainsKey(typeof(DesiredType)) {
        DesiredType item = items.First();
        ...
    }
