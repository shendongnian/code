    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
                XElement sample = XElement.Load("c:\\sample.xml");
                IEnumerable<XElement> open_elements = sample.Descendants().Where(c => c.Name.LocalName == "Opening").Where(c => c.Descendants().Where(d => d.Name.LocalName == "CartesianPoint").Count() > 4);
                foreach (XElement ele in open_elements){
                    Console.Write(ele.Attribute("id"));
                }
                Console.ReadKey();
            }
        }
    }
