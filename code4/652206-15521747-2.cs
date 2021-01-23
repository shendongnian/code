    //xml variable contains string representation of your xml
    //use XDocument.Load(filePath) to load xml having path to a file
    var nodes = XDocument.Parse(xml)
    					 .Descendants("Knowledge")
    					 .Elements("Group")
    					 .Elements("Item");
    
    var queryKnowledge = from item in nodes
                                 select new
                                 {
                                     Group = (string)item.Parent.Attribute("name"),
                                     Name = (string)item.Attribute("name"),
                                     Level = (string)item.Attribute("level")
                                 };
