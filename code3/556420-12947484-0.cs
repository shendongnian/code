    var list = XDocument.Load(xmlPath)
                        .Descendants("row")
                        .Descendants("cell")
                        .Attributes("value").ToList();
    var dic = Enumerable.Range(0, list.Count/2)
        .ToDictionary(i => list[2*i], i => list[2*i + 1]);
