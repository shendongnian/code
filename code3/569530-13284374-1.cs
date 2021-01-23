    XElement xml = XElement.Load("somedata.xml");
    
    //Find the Number of Duplicates
    IEnumerable<int> duplicateCount = xml.Descendants("Term")
                                        .GroupBy(xe => xe.Attribute("Name").Value)
                                       .Where(x => x.Key == "Hurricanes")
                                     .Select(y => y.Count());
    
    //Remove all duplicates and keep one
    xml.Descendants("Term").Where(xe => xe.Attribute("Name").Value == "Hurricanes")
                          .Take(duplicateCount.First()-1)
                         .Remove();
                                               
    xml.Save("moddata.xml");
                                                  
