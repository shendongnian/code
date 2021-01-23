    public class Node : IXmlSerializable {
        public Node() {
            NodeDocument = new Document();
        }
        public Document NodeDocument { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }
        public void ReadXml(XmlReader reader) {            
            reader.ReadStartElement();
            NodeDocument.File = reader.ReadString();
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer) {
            writer.WriteStartElement("file");
            writer.WriteString(NodeDocument.File);
            writer.WriteEndElement();
        }
    }
    public class Document {
        public String File { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            var node = new Node();
            node.NodeDocument.File = "bbb.txt";
            Serialize<Node>("a.xml", node);
            node = Deserialize<Node>("a.xml");
            Console.WriteLine(node.NodeDocument.File);
            Console.Read();
        }
        static T Deserialize<T>(String xmlFilePath) where T : class {
            using (var textReader = File.OpenText(xmlFilePath)) {
                using (var xmlTextReader = new XmlTextReader(textReader)) {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(xmlTextReader);
                }
            }
        }
        static void Serialize<T>(String xmlFilePath, T obj) where T : class {
            using (var textWriter = File.CreateText(xmlFilePath)) {
                using (var xmlTextWriter = new XmlTextWriter(textWriter)) {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(xmlTextWriter, obj);
                }
            }
        }
    }
