    using System;
    using System.Xml.Linq;
    
    public class Test 
    {
        static void Main() 
        {
            XDocument doc = new XDocument();
            doc.Add(new XElement("foo", new XElement("bar")));
            Console.WriteLine("Before:");
            Console.WriteLine(doc);
            Console.WriteLine();
            XContainer container = doc.Root;
            XElement headElement = new XElement("head");
            XElement bodyElement = new XElement("body", container);
            container.ReplaceWith(new XElement("html", headElement, bodyElement));
            Console.WriteLine("After:");
            Console.WriteLine(doc);
        }
    }
