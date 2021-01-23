    foreach (var item in xd.Descendants(ns + "Items").Elements(ns + "Item"))
    {
        // Do anything you need on a per-item basis here
        Console.WriteLine("Got item: {0}", item.Element("ASIN").Value);
        var colors = item.Elements(ns + "Variations")
                         .Elements(ns + "Item")
                         .Elements(ns + "ItemAttributes")
                         .Elements(ns + "Color")
                         .Select(x => x.Value);
        foreach (var color in colors)
        {
            Console.WriteLine("  Color: {0}", color);
        }
    }
