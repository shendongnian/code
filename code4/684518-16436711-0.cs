    using System;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                string xml = "<root><if attribute=\"cat\"></if><if attribute=\"dog\"></if><if attribute=\"rabbit\"></if></root>";
                XElement root = XElement.Parse(xml);
                int result = root.Descendants("if")
                    .Select(((element, index) => new {Item = element, Index = index}))
                    .Where(item => item.Item.Attribute("attribute").Value == "dog")
                    .Select(item => item.Index)
                    .First();
                Console.WriteLine(result);
            }
        }
    }
