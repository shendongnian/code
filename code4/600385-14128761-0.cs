    public class StackOverflow_14128649
    {
        public static void Test()
        {
            string myInputXmlString = @"<ApplicationData>
                                            <something>else</something>
                                        </ApplicationData>";
            var doc = new XmlDocument();
            doc.LoadXml(myInputXmlString);
            XmlAttribute newAttr = doc.CreateAttribute(
                "xsi", 
                "noNamespaceSchemaLocation", 
                "http://www.w3.org/2001/XMLSchema-instance");
            doc.DocumentElement.Attributes.Append(newAttr);
            var ms = new MemoryStream();
            XmlWriterSettings ws = new XmlWriterSettings
            {
                OmitXmlDeclaration = false,
                ConformanceLevel = ConformanceLevel.Document,
                Encoding = UTF8Encoding.UTF8
            };
            var tx = XmlWriter.Create(ms, ws);
            doc.Save(tx);
            tx.Flush();
            var xmlString = UTF8Encoding.UTF8.GetString(ms.ToArray());
            Console.WriteLine(xmlString);
        }
    }
