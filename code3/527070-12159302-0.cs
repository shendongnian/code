    Server s = new Server();
    s.UserName = "Bob";
    s.UserGroups = new List<string>();
    s.UserGroups.Add("History");
    s.UserGroups.Add("Geography");
    StringWriter stream = new StringWriter();
    XmlWriter writer = 
                XmlTextWriter.Create(
                  stream,
                  new XmlWriterSettings() { OmitXmlDeclaration = true,Indent = true }
                );
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("i", "http://www.w3.org/2001/XMLSchema-instance");
    XmlSerializer xml = new XmlSerializer(typeof(Server));
    xml.Serialize(writer,s,ns);
    var xmlString = stream.ToString();
---
    public class Server
    {
        public string UserName;
        [XmlArrayItem("UserGroup")]
        public List<string> UserGroups;
    }
