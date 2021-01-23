    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string xml = "<foo>&#31;</foo>";
            XDocument.Parse(xml);
        }
    }
