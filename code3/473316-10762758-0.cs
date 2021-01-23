    using System.Xml.Linq;
    var doc = XDocument.Parse(@"...");
    var element = doc.XPathSelectElement("/users/user[@id='John']");
    var website = element.XPathSelectElement("website").Value;
    var type = int.Parse(element.XPathSelectElement("type").Value);
