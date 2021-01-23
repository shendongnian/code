    XDocument xdoc = XDocument.Load("file.xml");
    IEnumerable<double> values =
        xdoc.Descendants("item")
            .Where(i => (string)i.Element("name") == "theName2") // select item
            .Select(i => i.Element("name")) // select name node 
            .SelectMany(e => e.ElementsAfterSelf()) // take siblings
            .Select(v => (double)v); // convert all value nodes to double
