    var xDoc = XDocument.Parse(xmlstring);
    var files = xDoc.Descendants("file")
                    .Select(f => String.Format("{0} {1}",
                                                String.Join("/",GetPath(f).Reverse()),
                                                f.Attribute("md5").Value))
                    .ToList();
    IEnumerable<string> GetPath(XElement e)
    {
        while(e!=null) {
            yield return e.Attribute("name").Value;
            e = e.Parent;
        }
    }
