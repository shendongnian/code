    XDocument doc = XDocument.Load(Path);
                
    //To get <id>
    var MyIds = doc.Element("FactionAttributes").Element("id").Value;
    
    //To get <id0>, <id1>, etc.
    var result = doc.Element("FactionAttributes")
                    .Element("relations")
                    .Elements()
                    .Where(E => E.Name.ToString().Contains("id"))
                    .Select(E => new { IdName = E.Name, Value = E.Value});
