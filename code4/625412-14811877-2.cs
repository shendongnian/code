    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.XPath;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                string xml = "<xml-header><error code=\"40\" message=\"errorMessage\" /></xml-header>";
            
                var element = XElement.Load(new StringReader(xml));
                var errorElement = element.XPathSelectElement("error");
                string code = errorElement.Attribute("code").Value;
                Console.WriteLine(code); // Prints 40
            }
        }
    }
