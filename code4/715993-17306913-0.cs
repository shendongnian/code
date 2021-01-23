    var nameTable = new NameTable();
    var nsMgr = new XmlNamespaceManager(nameTable);
    nsmgr.AddNamespace("nc", "http://some.url/");
    var dataNodes = xmlDoc.SelectNodes("nc:RecordFilingRequest/nc:DocumentIdentification", nsMgr);
    foreach (var node in dataNodes)
    {
        var ID = Convert.ToInt32(node.SelectSingleNode("IdentificationID", nsMgr).InnerText);
        // insert into database, e.g. using SqlCommand or whatever
    }
