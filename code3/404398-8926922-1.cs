    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    XmlWriterSettings xws = new XmlWriterSettings();
    xws.OmitXmlDeclaration = true;
    xws.Indent = true;
    
    using (var stream = File.Create(@"C:\test.xml"))
    using (XmlWriter xw = XmlWriter.Create(stream, xws))
    {
        var xml = new XElement(
            "root",
            new XElement("subelement1", "1"),
            new XElement("subelement2", "2"));
    
        xml.Save(xw);
    }
