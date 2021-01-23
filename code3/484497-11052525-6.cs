    XElement xml;
    var empties = xml.Descendants().Where(x => x.IsEmpty && !x.HasAttributes).ToList();
	while (empties.Count > 0) {
		var parents = empties.Select(e => e.Parent)
							 .Where(e => e != null)
							 .Distinct()	//In case we have two empty siblings, don't try to remove the parent twice
							 .ToList();
		empties.ForEach(e => e.Remove());
		//Filter the parent nodes to the ones that just became empty.
		parents.RemoveAll(e => e.IsEmpty && !e.HasAttributes);
		empties = parents;
	}
