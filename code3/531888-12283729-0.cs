    var addedNames = new HashSet<string>(
        liveXml.Elements().Select(e => e.Name).Except(
            defXml.Elements().Select(e => e.Name)
        )
    );
    var addedElements = liveXml
        .Elements()
        .Where(e => addedNames.Contains(e.Name))
        .ToList();
