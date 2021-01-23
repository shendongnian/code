     System.Xml.Linq.XDocument doc = XDocument.Load(YOUR XML FILE PATH);
     var result = doc.Element("Accounts").Elements("account").Select(i => new
     {
                Id = i.Attribute("ID").Value,
                User = i.Element("UserName").Value,
                Pass = i.Element("Password").Value
     }).ToList();
