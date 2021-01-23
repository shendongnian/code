    // find nodes 
    XNamespace ns = "url....";
    var doc = XDocument.Load("Test.xml");
    var items =( from item in doc.Descendants(ns+"Document").Descendants(ns+"Item")
                where CheckItem(item.Element(ns+"th").Value)
                select item).ToList();
    // update nodes 
    for (int i = 0; i < items.Count(); i++)
    {
        items[i].SetElementValue(ns + "color", GetColor(items[i].Value));
    }
    // saving updated xml 
    doc.Save("Test.xml");
