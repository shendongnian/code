    XDocument xml = XDocument.Load(name.Value); 
    IEnumerable<XElement> columns = xml.Descendants("DataContainer") 
                                       .Where(d => d.Attribute("Name").Value.Equals(name.Key)) 
                                       .Single()
                                       .Select(d => d.Descendants("ArrayOfColumn")); 
