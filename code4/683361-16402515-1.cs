    // add
    var dict = (from item in doc.Descendants("SUM")
                select new  Item
                {                                    
                    ID = (string)item.Attribute("id"),
                    Category = (string)item.Attribute("cat"),
                    Selection = (string)item.Attribute("sel")
                })
                .ToDictionary(i=>i.ID, i=>i);
    // lookup
    Item foundItem = dict[lookupID];
