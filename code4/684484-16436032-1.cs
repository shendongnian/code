    using System;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                XElement root = 
                    new XElement("order",
                        new XElement("clientId", 1001),
                        new XElement("config",
                            new XElement("properties",
                                new XElement("entry", new XAttribute("key", "RecordTotal"), 10),
                                new XElement("entry", new XAttribute("key", "InputFileName"), "name"),
                                new XElement("entry", new XAttribute("key", "ConfigName"), "COMMON"),
                                new XElement("entry", new XAttribute("key", "DeliveryDate"), "15-FEBRUARY-2013"),
                                new XElement("entry", new XAttribute("key", "Qualifier"), "name")),
                            new XElement("id", 19)),
                        new XElement("orderID", 58239346)
                );
                Console.WriteLine(root);
            }
        }
    }
