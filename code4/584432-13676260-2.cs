    var temp = Elements.GroupBy(e => e.Name)
                       .Select(g => new Element
                       {
                           ID = g.OrderBy(e => e.ID).First().ID,
                           Name = g.Key,
                           Children = g.SelectMany(e => e.Children).ToList(),
                           Parents = g.SelectMany(e => e.Parents).ToList()
                       });
    var duplicates = Elements.Where(e => !temp.Any(t => t.ID == e.ID))
                             .Select(e => e.ID)
                             .Distinct();
    Elements = new HashSet<Element>(temp);
    foreach (Element e in Elements)
    {
        e.Children.RemoveAll(i => duplicates.Contains(i));
        e.Parents.RemoveAll(i => duplicates.Contains(i));
    }
