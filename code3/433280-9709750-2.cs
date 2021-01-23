    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("test.xml");
            XNamespace ns = "http://test-namespace1";
            
            var query =
                  from element in doc.Descendants(ns + "CustomProperty")
                  select new {
                     Description = element.Element(ns + "descriptionField").Value,
                     Furniture = element.Element(ns + "furnitureField").Value
                  };
            
            foreach (var record in query)
            {
                Console.WriteLine(record);
            }
        }
    }
