    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var child = doc.Root.Element("child");
            var text = child.Value;
            Console.WriteLine("Text: {0}", text);
        }
    }
