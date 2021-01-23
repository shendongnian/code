    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<form name='oldvalue' action='old_value' method='get' />");
                foreach (XmlNode node in doc.GetElementsByTagName("form"))
                {
                    node.Attributes["action"].Value = "new_value";
                }
                Console.Write(doc.OuterXml);
                Console.Read();
            }
        }
    }
