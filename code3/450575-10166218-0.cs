    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main()
        {
            string url =
                 "http://gdata.youtube.com/feeds/api/standardfeeds/most_popular";
            var doc = XDocument.Load(url);
            XNamespace ns = "http://www.w3.org/2005/Atom";
            var links = doc.Root
                           .Elements(ns + "entry")
                           .Elements(ns + "link")
                           .Where(x => (string) x.Attribute("rel") == "alternate");
            
            Console.WriteLine(links.Count()); // 25
        }
    }
