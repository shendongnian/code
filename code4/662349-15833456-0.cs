    using System;
    using System.Xml;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            using (var reader = XmlReader.Create("test.xml"))
            {
                while (reader.ReadToFollowing("foo"))
                {
                    XElement element = XElement.Load(reader.ReadSubtree());
                    Console.WriteLine("Title: {0}", element.Attribute("title").Value);
                }
            }
        }
    }
