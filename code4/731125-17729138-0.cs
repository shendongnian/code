    // TODO: Find a nicer way of doing this; you shouldn't need to parse it again
    XElement root = XElement.Parse(siteUsers.InnerXml);
    var siteUserElements = root.Elements(ns + "User")
                               .Where(el => (int) el.Attribute("ID") == 814);
    foreach (XElement el in siteUserElements)
    {
        Console.WriteLine("el: " + el);
    }
