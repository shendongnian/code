    var data = from item in xmlDoc.Root.Elements("category")
               where item.Attribute("value").Value == "idxCategoryPlatformEngine"
               select new
                   {
                       category = item.Attribute("value").Value,
                       attributes = from attr in item.Element("attributes")
                                    select new {
                                       attribute = attr.Element("name").Value,
                                       trigger = attr.Element("trigger").Value,
                                       ...
                                    }
                   };
