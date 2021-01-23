    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XNamespace ns = "http://www.uk.nds.com/SSR/XTI/Traffic/0010";
            XDocument doc = XDocument.Load("test.xml");
            
            var elements = doc.Descendants(ns + "displayDateTime")
                              .ToList();
            
            var today = DateTime.Today;
            foreach (var element in elements)
            {
                element.ReplaceAll(today);
            }
            Console.WriteLine(doc);
        }
    }
