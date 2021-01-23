    var temp = Elements.GroupBy(e => e.Name)
                       .Select(g => new Element
                       {
                           ID = g.OrderBy(e => e.ID).First().ID,
                           Name = g.Key,
                           Children = g.SelectMany(e => e.Children).ToList(),
                           Parents = g.SelectMany(e => e.Parents).ToList()
                       });
    Elements = new HashSet<Element>(temp);
