    XNamespace ns = docWithDecode.Root.Name.Namespace;
    XElement xGlobal = docWithDecode.Root.Element(ns + "Global");
    forach (XElement xItems in xGlobal.Elements(ns + "Items")
    {
       XAttribute outerItemText = xItems.Attribute("text");
       XAttribute outerItemKey = xItems.Attribute("key");
       
       foreach (XElement xItem in xItems.Elements(ns + "Item"))
       {
          XAttribute innerItemText = xItem.Attribute("text");
          XAttribute innerItemKey = xItem.Attribute("key");
       }
    }
