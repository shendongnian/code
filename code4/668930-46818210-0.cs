    XDocument doc = XDocument.Load(Server.MapPath(@"~\App_GlobalResources\myResource2.resx"));
    
    XElement data = new XElement("data");
    
    XNamespace ns = "xml";
    data.Add(new XAttribute("name", "v13"));
    data.Add(new XAttribute(XNamespace.Xml + "space", "preserve"));
    
    data.Add(new XElement("value", "Test TEst"));
    
    doc.Element("root").Add(data);
    doc.Save(Server.MapPath(@"~\App_GlobalResources\myResource2.resx"));
