    var root = new PathNode(String.Empty);
    var links = new[] { "/node1/sub-node1", "/node1", "/node2/sub-node-2", "/node2", "/node2/sub-node-1" };
    foreach (var link in links) {
        if (String.IsNullOrWhiteSpace(link)) {
            continue;
        }
        var node = root;
        var lastIndex = link.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
        if (lastIndex < 0) {
            node.AddChild(link);
            continue;
        }
        while (lastIndex >= 0) {
            lastIndex = link.IndexOf("/", lastIndex + 1, StringComparison.InvariantCultureIgnoreCase);
            
            node = node.AddChild(lastIndex > 0 
                ? link.Substring(0, lastIndex) // Still inside the link 
                : link // No more slashies
            );
        }
    }
    var orderedLinks = new List<string>();
    root.Traverse(pn => orderedLinks.Add(pn.Name));
    foreach (var orderedLink in orderedLinks.Where(l => !String.IsNullOrWhiteSpace(l))) {
        Console.Out.WriteLine(orderedLink);
    }
