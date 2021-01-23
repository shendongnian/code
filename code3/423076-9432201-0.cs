    using System.Linq;
    using System.Xml.Linq;
    var xdoc = XDocument.Load("c:\\test.xml");
    var names = xdoc.Descendants("Root")
                    .Descendants("Username")
                    .Elements()
                    .Select(n => n.Value);
    
    var doc = new XDocument(
                    new XElement("Root", 
                        names.Select(i => new XElement("Username", i))));
    // TODO: Save doc using doc.WriteTo(xmlWriter) to the file
