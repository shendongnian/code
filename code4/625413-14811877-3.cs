    using System;
    using System.IO;
    using System.Xml.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                string xml = "<xml-header><error code=\"40\" message=\"errorMessage\" /></xml-header>";
            
                var doc = XDocument.Load(new StringReader(xml));
                var errorElement = doc.Element("xml-header").Element("error");
                string code = errorElement.Attribute("code").Value;
                Console.WriteLine(code);  // Prints 40
            }
        }
    }
