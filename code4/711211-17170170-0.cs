    XDocument xdoc = XDocument.Load("myXml.xml");
    List<Item> items = (from item in xdoc.Descendants("item")
                        select new Item {
                        Name = item.Element("name").Value,
                        Price = item.Element("price").Value
                        }).ToList();
