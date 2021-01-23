    var xDoc = XDocument.Parse(xml); //or XDocument.Load(fileName)
    var list =  xDoc.Descendants("ordinanza")
                    .Select(n => new
                    {
                        Numero = n.Element("numero").Value,
                        Titolo = n.Element("titolo").Value,
                    })
                    .ToList();
