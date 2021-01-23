      var xDoc = XDocument.Load(inputPathToConfigFile);
                    var ns = xDoc.Descendants().First(x => x.Name.LocalName == "configuration").Name.Namespace;
    
                    var prop = xDoc.Descendants(ns + "membership")
                    .First(p => p.Attribute("defaultProvider").Value == "SQLMembershipProvider");
    
                   if(prop.HasAttributes)
                   {
                       var prop1 = prop.Descendants(ns + "add").First(p => p.Attribute("type").Value == "System.Web.Security.SqlMembershipProvider");
                       prop1.Attribute("type").Value = "sample.membershipprovider";
                       xDoc.Save(inputPathToConfigFile);
                   
                   }
