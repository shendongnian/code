    using System;
    using System.Xml;
    
    class Test
    {
        public static void Main(string[] args)
        {
            using (var writer = XmlWriter.Create(Console.Out))
            {
                writer.WriteStartElement("ns1", "foo", "http://someurl/schemas");
                writer.WriteAttributeString("xmlns", "ns1", null, "http://someurl/schemas");
                writer.WriteEndElement();
            }
        }
    }
