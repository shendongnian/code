    // Will return "a" - one which you already had
    var duplicatesBetweenNames = list.GroupBy(i => i.Name)
        .Where(g => g.Count() > 1)
        .Select(g => g.Key).ToArray();
    var duplicatedInSName = list.Select(x => x.Name)
        .Intersect(list.Select(x => x.SName));
    // Will return "c" - represents Names where in SName is duplicate
    var duplicatesBetweenNameAndSName = list
        .Where(f => duplicatedInSName.Contains(f.SName))
        .Select(x=>x.Name).ToArray();
