        var doc = XDocument.Parse("<xml . ../>");
        
        foreach (var item in doc.Element("Values").Elements("Item").OrderBy(x=>x.Attribute("ID").Value))
        {
     
            var type = item.Attribute("Type").Value;
    
            if (type=="Notification")
            {
               // processing code here
            }
        }
