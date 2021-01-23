    using System.Collections.Generic;
    using System.Xml.Linq;
    namespace TraverseXMLNodes
    {
        public class Class1
        {
            public static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(@"C:\Udvikling\StackOverflow\TraverseXMLNodesSln\TraverseXMLNodes\XMLFile1.xml");
                var msgs = doc.Element("root").Elements("Msg");
                List<int> numbers = new List<int>();
                List<string> numbersStr = new List<string>();
                int count = 0;
                foreach (var xElement in msgs)
                {
                    string value = xElement.Attribute("UserText").Value;
                    numbersStr.Add(value);
                    if (value.Contains("start"))
                    {
                        numbers.Add(count);
                        count = 0;
                    }
                    else
                    {
                        count++;
                    }
                }
                numbers.Add(count);
            }
        }
    }
