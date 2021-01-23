    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("test.xml");
            XNamespace ns = "http://www.TestWebsite.com/schema/data";
            var query = doc.Descendants(ns + "INTEL");
            Console.WriteLine(query.Count()); // Prints 1
        }
    }
