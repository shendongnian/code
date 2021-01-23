    XElement xml = XElement.Load("data.xml");
    string toRemove ="Hurricanes";
    
    //Find the Number of Duplicates
    int duplicateCount=xml.Descendants("Term")
                          .GroupBy(xe => xe.Attribute("Name").Value)
                          .Where(x => x.Key == toRemove)
                          .Select<IGrouping<string, XElement>, int>(y => y.Count())
                          .First();
    
    //Remove all duplicates and keep one
    xml.Descendants("Term").Where(xe => xe.Attribute("Name").Value == toRemove)
                           .Take(duplicateCount-1)
                           .Remove();
                                               
    xml.Save("moddata.xml");
                                                  
