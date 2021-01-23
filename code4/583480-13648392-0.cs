        using System;
        using System.Xml;
        class Program
        {
            static void Main(string[] args)
            {
                XmlWriter writer = new XmlTextWriter(Console.Out);
                writer.WriteStartElement("root");
                writer.WriteAttributeString("news", "http://www.stackoverflow.com");
                writer.WriteStartElement("news:news");
                writer.WriteStartElement("news:publication");
                writer.WriteElementString("news:name", "The Example Times");
                writer.WriteElementString("news:language", "en");
                // etc
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                Console.ReadKey(true);
            }
        }
