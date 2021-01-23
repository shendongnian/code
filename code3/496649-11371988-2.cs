    XDocument XmlRoot = XDocument.Load( "C:\\somefile.xml" );
    
    // Get item nodes
    var items = XmlRoot.Descendants("item");
    
    // Find duplicate items keys using creator attribute
    var duplicateItemKeys = items.GroupBy(x => x.Attribute("creator").Value)
         .Where(g => g.Count() > 1)
         .Select(g => g.Key);
    
    // Get the duplicate item XML elements using the duplicate keys
    var duplicateItems = items.Where(i => duplicateItemKeys.Contains(i.Attribute("creator").Value))
         .OrderBy( xelement => xelement.Attribute("id").Value );
    
    // Get the child nodes named childB
    var allItemB = new List<XElement>();
    allItemB.AddRange( duplicateItems.Descendants("childB") );
