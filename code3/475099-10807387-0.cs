    public class StackOverflow_10807173
    {
        public static void Test()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement RootElement = (XmlElement)doc.AppendChild(
                doc.CreateElement("root"));
            string[] CSV = "hello world how are you".Split(' ');
            int nodeCount = 0;
            XmlAttribute xmlnsAttr = doc.CreateAttribute(
                "xmlns", "acp", "http://www.w3.org/2000/xmlns/");
            string acpNamespace = "http://www.namespace.com";
            xmlnsAttr.Value = acpNamespace;
            RootElement.Attributes.Append(xmlnsAttr);
            foreach (string line in CSV)
            {
                XmlElement navPointElement = (XmlElement)RootElement.AppendChild(
                    doc.CreateElement("navPoint"));
                XmlElement navPointTypeElement = (XmlElement)navPointElement.AppendChild(
                    doc.CreateElement("type", acpNamespace)); // namespace here
                navPointTypeElement.Prefix = "acp";
                navPointTypeElement.InnerText = nodeCount == 0 ? "cover" : "article";
            }
            Console.WriteLine(doc.OuterXml);
        }
    }
