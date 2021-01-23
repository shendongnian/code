    using System;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            XNamespace @namespace = "PanelControls";
            XElement element = new XElement("root",
                new XAttribute(XNamespace.Xmlns + "PanelControls", @namespace),
                new XElement(@namespace + "FrequencyButtonA",
                    new XAttribute("Frequency", 113.123),
                    new XAttribute("Width", 250)));
            Console.WriteLine(element);
        }
    }
