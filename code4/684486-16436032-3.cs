    using System;
    using System.Collections.Generic;
    using System.Linq;
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
                                createEntries(getEntries())),
                            new XElement("id", 19)),
                        new XElement("orderID", 58239346)
                );
                Console.WriteLine(root);
            }
            static IEnumerable<Entry> getEntries()
            {
                yield return new Entry
                {
                    RecordTotal   = 10,
                    InputFileName = "name",
                    ConfigName    = "COMMON",
                    DeliveryDate  = "15-FEBRUARY-2013",
                    Qualifier     = "name"
                };
                yield return new Entry
                {
                    RecordTotal   = 15,
                    InputFileName = "othername",
                    ConfigName    = "UNCOMMON",
                    DeliveryDate  = "23-FEBRUARY-2013",
                    Qualifier     = "qname"
                };
            }
            static IEnumerable<XElement> createEntries(IEnumerable<Entry> entries)
            {
                return from entry in entries
                       select new XElement(
                           "property",
                           new XElement("entry", new XAttribute("key", "RecordTotal"),   entry.RecordTotal),
                           new XElement("entry", new XAttribute("key", "InputFileName"), entry.InputFileName),
                           new XElement("entry", new XAttribute("key", "ConfigName"),    entry.ConfigName),
                           new XElement("entry", new XAttribute("key", "DeliveryDate"),  entry.DeliveryDate),
                           new XElement("entry", new XAttribute("key", "Qualifier"),     entry.Qualifier));
            }
        }
        sealed class Entry
        {
            public int RecordTotal;
            public string InputFileName;
            public string ConfigName;
            public string DeliveryDate;
            public string Qualifier;
        }
    }
