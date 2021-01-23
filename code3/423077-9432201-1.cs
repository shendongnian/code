    using System.Linq;
    using System.Xml.Linq;
    var indoc = XDocument.Load("c:\\test.xml");   
    var outdoc = new XDocument(
                  new XElement("Root", 
                    indoc.Descendants("Root")
                         .Descendants("Username")
                         .Elements()
                         .Select(n => n.Value)
                         .Select(i => new XElement("Username", i))));
    // TODO: Save doc using doc.WriteTo(xmlWriter) to the file
