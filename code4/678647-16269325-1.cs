    var queryValue = "Quantity";
    var xDoc = XDocument.Load(@"UserVars.xml");//This is your xml path value
    var userVar = xDoc.Descendents("UserVar").Where(x => x.Element("Name").Value == queryValue )
                      .FirstOrDefault();
    var name     = userVar.Element("Name").Value ?? string.Empty;
    var width    = userVar.Element("Width").Value ?? string.Empty;
    var varValue = userVar.Element("VarValue").Value ?? string.Empty;
