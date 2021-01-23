    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Porgram
        {
            static void Main(string[] args)
            {
                string xml = "<ArrayOfstring  xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><string>hello</string><string>world</string><string>!</string></ArrayOfstring>";
                XDocument doc = XDocument.Parse(xml);
    
                XNamespace ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
    
                var text = from str in doc.Root.Elements(ns + "string")
                        select str.Value;
                foreach (string str in text)
                {
                    Console.WriteLine(str);
                }
                Console.ReadKey();
            }
        }
    }
