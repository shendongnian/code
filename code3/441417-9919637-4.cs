    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            foreach (var child in doc.Root.Elements())
            {
                Console.WriteLine("{0}: {1}",
                                  child.Name, child.Value);
            }
        }
    }
