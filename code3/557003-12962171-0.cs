    XDocument xDoc = XDocument.Parse(xml); //or XDocument.Load(filename);
    var rows = xDoc.XPathSelectElement("//Dataset[@name='OutputData']")
                .Descendants("Row")
                .Select(r => new XMLDetails
                {
                    country = r.Element("country").Value,
                    pubyear = r.Element("pubyear").Value,
                    numart = r.Element("numart").Value,
                    numcites = r.Element("numcites").Value,
                })
                .ToList();
