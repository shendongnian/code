    string xml = new WebClient().DownloadString(url);
    XDocument doc = XDocument.Parse(xml);
    var itemDescendent = xeCrit.Descendants("item"); //item being the name of the node
    from item in itemDescendent
    select new
              {
                 itemId = item.Attribute("id"),
                 itemName = item.Attribute("Name")
              };
