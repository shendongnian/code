    XDocument xml = new XDocument();
    XElement root = new XElement("Root");
    xml.Add(root);
    root.Add(new XElement("Item1"));
    root.Add(new XElement("Item2"));
    if (x == 42)
       root.Add(new XElement("Item2.5"));
    root.Add(new XElement("Item3"));
    root.Add(new XElement("Item4"));
