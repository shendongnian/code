    XDocument xmlDoc = new XDocument();
    xmlDoc = XDocument.Parse(xml);
    XNamespace ns = "#RowsetSchema";
    var namesDescs = from namesDesc in xmlDoc.Descendants().Elements(ns + "row")
        select new
        {
           name = namesDesc.Attribute("NAME").Value,
           description = namesDesc.Attribute("DESCRIPTION").Value,
        };
