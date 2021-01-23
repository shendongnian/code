    XmlDocument doc = new XmlDocument();
    doc.Load(@"G:\MyProjects\checking response\checking response\XMLFile1.xml");
    StringWriter sw = new StringWriter();
    XmlTextWriter xw = new XmlTextWriter(sw);
    doc.WriteTo(xw);
    
    String xml = sw.ToString();
    System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Parse(xml);
    List<System.Xml.Linq.XElement> xlist = xdoc.Descendants(System.Xml.Linq.XName.Get("schema")).ToList();
    foreach (var item in xlist)
    {
    	Response.Write(item.Element("schemaname").ToString() + item.Element("tcmid").ToString() + item.Element("dummycomponentsource").ToString() + "<br>");
    }
