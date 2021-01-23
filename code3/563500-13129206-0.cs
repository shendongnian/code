    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Porgram
        {
            static void Main(string[] args)
            {
                string xml = "<ArrayOfstring><string>hello</string><string>world</string><string>!</string></ArrayOfstring>";
                XDocument doc = XDocument.Parse(xml);
    
                var text = from str in doc.Root.Elements("string")
                        select str.Value;
                foreach (string str in text)
                {
                    Console.WriteLine(str);
                }
                Console.ReadKey();
            }
        }
    }
