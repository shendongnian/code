    XDocument doc = XDocument.Load(path);
    IEnumerable<XElement> policyChangeSetCollection = doc.Elements("PolicyChangeSet");
    
    foreach(XElement node in policyChangeSetCollection)
    {
       node.Attribute("username").SetValue(someVal1);
       node.Attribute("description").SetValue(someVal2);
       XElement attachment = node.Element("attachment");
       attachment.Attribute("name").SetValue(someVal3);
       attachment.Attribute("contentType").SetValue(someVal4);
    }
    
    doc.Save(path);
