    using(var stream = new StringReader(xml))
    {
        XDocument xmlFile = XDocument.Load(stream);
        var query = (IEnumerable) xmlFile.XPathEvaluate("/REETA/AFFIDAVIT/COUNTY_NAME");
        foreach(var band in query.Cast < XElement > ())
        {
            Console.WriteLine(band.Value);
        }
        xmlFile.Save("books.xml");
    }
