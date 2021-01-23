    XElement xml;
    var empties = xml.Descendants().Where(x => x.IsEmpty).ToList();
    while (empties.Count > 0) {
        var parents = empties.Select(e => e.Parent)
                             .Where(e => e != null)
                             .ToList();
        empties.ForEach(e => e.Remove());
        //Filter the parent nodes to the ones that just became empty.
        parents.RemoveAll(e => !e.IsEmpty);
        empties = parents;
    }
