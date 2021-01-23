    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {    
        public static void Main()
        {
            var doc = XDocument.Load("Test.xml");
            var query = doc.Descendants("EventSet")
                           .Descendants("Event");
            Console.WriteLine(query.Count()); // 1
        }    
    }
