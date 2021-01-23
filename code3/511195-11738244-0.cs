    var nodes = new Dictionary<string, List<string>>();
    XmlDocument document = new XmlDocument();
    foreach (XmlNode childNode in document.ChildNodes)
    {
        if(nodes.ContainsKey(childNode.Name))
            nodes[childNode.Name].Add(childNode.InnerText);
        else
            nodes.Add(childNode.Name, new List<string> {childNode.InnerText});
    }
    // and printing
    foreach (var node in nodes)
    {
        Console.WriteLine(node.Key + " got " + String.Join("|", kvp.Value.ToArray()));
    }
