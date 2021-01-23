    var col = root.ChildNodes.Cast<XmlNode>()
                                 .Where(child => child.Attributes["disabled"] != null &&
                                                 Convert.ToBoolean(child.Attributes["disabled"].Value)).ToList();
    
    foreach (XmlNode node in col)
    {
        Console.WriteLine("Removing:");
        Console.WriteLine(XDocument.Parse(node.OuterXml).ToString());
        root.RemoveChild(node);
    }
