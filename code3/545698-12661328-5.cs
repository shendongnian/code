    string xml =
        @"<main>
            <myself>
                <pid>1</pid>
                <name>abc</name>
            </myself>
            <myself>
                <pid>2</pid>
                <name>efg</name>
            </myself>
          </main>";
    using System.Xml;
    ....
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(xml);
    // Replace "2" in the string below with the desired pid
    XmlNode xmlNode = 
        xmlDocument.DocumentElement.SelectSingleNode("myself/name[../pid=2]");
    // xmlNode contains the <name>efg</name> XmlElement. For example:
    string name = xmlNode.Value;
