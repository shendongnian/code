    using System;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var xml = XDocument.Load("test.xml");
            xml.Root.Element("statrecords").SetAttributeValue("value", 2);
            Console.WriteLine(xml);
        }    
    }
