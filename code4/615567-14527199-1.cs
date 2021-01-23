    string xml = new WebClient().DownloadString(url);
    XDocument doc = XDocument.Parse(xml);
    //item being the name of the node
    var itemDescendent = doc.Descendants("item"); 
    var query = from item in itemDescendent
                select new
                {
                   itemId = item.Attribute("id"),
                   itemName = item.Attribute("Name")
                };
    foreach (item in query)
    {
       //dostuff
    }
