      XDocument xmlDoc = XDocument.Load("myXML.xml");
      var data = (from items in xmlDoc.Root.Elements("category")
                  where items.Attribute("value").Value == "idxCategoryPlatformEngine"
                  select new {attrs  = items.Element("attributes")})
                  .SelectMany(a => a.attrs.Elements("attribute"))
                  .Select(item => new {
                           attribute = item.Element("name").Value,
                           trigger = item.Element("trigger").Value,
                           value = item.Element("value").Value,
                           minutes = item.Element("minutes").Value
                  });
