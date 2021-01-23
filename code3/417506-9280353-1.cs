    XDocument gutted = new XDocument(xDoc);
    gutted.Descendants(xDoc.Root.Name.Namespace + "Message").Remove();
    
    foreach(XElement element in elements)
    {
        XDocument newDoc = new XDocument(gutted);
        newDoc.Root.Add(element);
        // ...
    }
