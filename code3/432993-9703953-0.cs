    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create("test.xml"))
            {
                while (true)
                {
                    while (reader.NodeType != XmlNodeType.Element ||
                        reader.LocalName != "Child")
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Finished!");
                        }
                    }
                    XElement element = (XElement) XNode.ReadFrom(reader);
                    Console.WriteLine("Got child: {0}", element.Value);
                }
            }
        }
    }
