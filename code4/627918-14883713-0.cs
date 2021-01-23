    XmlDocument doc = new XmlDocument(); 
    doc.Load("whatever path to xml");
    var nodes = doc
        .SelectNodes("xpath query goes here")
        .Cast<XmlNode>()
        // optionally, convert to a list
        .ToList();
    // Outputs something like: 
    //   System.Collection.Generic.List`1[[System.Xml.XmlNode, ...]]
    Console.WriteLine(nodes.GetType().FullName);
