    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Test.xml");
                XmlElement root = doc.DocumentElement;
                foreach (var item in root)
                {
                    XmlElement elem = (XmlElement)item;
                    if (elem.InnerText.Equals(""))
                    {
                        foreach (var child in elem.ChildNodes)
                        {
                            XmlElement childelem = (XmlElement)child;
                            childelem.RemoveAll();
                        }
    
                        elem.ParentNode.RemoveChild(elem);
                    }
                }
                doc.Save("Test.xml");
                Console.ReadLine();
            }
        }
    }
