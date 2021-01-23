    // Find all duplicated elements and remove them
    var duplicates = Elements.GroupBy(x => x.Name)
                             .Where(x => x.Count() > 1)
                             .SelectMany(x => x.OrderBy(e => e.ID)
                                               .Skip(1)
                                               .Select(e => new { Element = e, NewID = x.Min(y => y.ID) }))
                             .ToDictionary(x => x.Element.ID, x => new { x.Element, x.NewID });
    Elements.ExceptWith(duplicates.Values.Select(x => x.Element));
    
    // Update the Children and Parents of each remaining element
    foreach (var element in Elements)
    {
        var removed = duplicates.Where(x => x.Value.Element.Name == element.Name);
    
        var mergedChildren = element.Children.Union(removed.SelectMany(x => x.Value.Element.Children))
                                             .Select(x => duplicates.ContainsKey(x) ? duplicates[x].NewID : x)
                                             .Distinct().ToList();
        element.Children.Clear();
        element.Children.AddRange(mergedChildren);
    
    
        var mergedParents = element.Parents.Union(removed.SelectMany(x => x.Value.Element.Parents))
                                           .Select(x => duplicates.ContainsKey(x) ? duplicates[x].NewID : x)
                                           .Distinct().ToList();
        element.Parents.Clear();
        element.Parents.AddRange(mergedParents);
    }
