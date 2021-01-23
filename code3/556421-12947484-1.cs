    var list = XDocument.Load("C:\\test.xml")
                .Descendants("section")
                .Where(e => e.Attribute("name").Value.Equals("DOBs"))
                .Descendants("row")
                .Descendants("cell")
                .Attributes("value").ToList();
    var dic = Enumerable.Range(0, list.Count/2)
        .ToDictionary(i => list[2*i], i => list[2*i + 1]);
