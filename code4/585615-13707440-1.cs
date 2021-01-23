    var objApps = from item in xDoc.Descendants("VHost") 
                         where(item.Descendants("Application").Any())
                         select new clsApplication
                         {
                               ConnectionsTotal = item.Element("Application").Element("ConnectionsTotal").Value
                         };
