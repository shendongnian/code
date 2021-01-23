    XDocument XmlRoot = XDocument.Load( "C:\\somefile.xml" );
    
    // Get item nodes
    var items = XmlRoot.Descendants("item");
    
    // Find duplicate items keys using creator attribute
    var duplicateItemKeys = items.GroupBy(x => x.Attribute("creator").Value)
         .Where(g => g.Count() > 1)
         .Select(g => g.Key);
    
    IEnumerable<XElement> duplicateItems = new List<XElement>();
    foreach(var duplicateItemKey in duplicateItemKeys)
    {
         // Get the duplicate item XML elements using the duplicate keys
         duplicateItems = items.Where(x => x.Attribute("creator").Value == duplicateItemKey)
              .OrderBy(xelement => xelement.Attribute("id").Value);
     }
    
     var allItemB = new List<XElement>();
     foreach (var duplicateItem in duplicateItems) 
     {
          allItemB.AddRange(duplicateItem.Descendants("childB"));
     }
