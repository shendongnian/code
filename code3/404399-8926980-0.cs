    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var xml =
                new XElement("root",
                             new XElement("subelement1", "1"),
                             new XElement("subelement2", "2"));
            
            var doc = new XDocument(xml);
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            using (var stream = File.Create(@"test.xml"))
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    doc.Save(writer);
                }
            }
        }
    }
