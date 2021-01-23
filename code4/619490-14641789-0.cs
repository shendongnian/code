    using System;
    using System.Xml;
    using System.Xml.Serialization;
    
    public class Foo
    {
        public string Bar { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var overrides = new XmlAttributeOverrides();
            overrides.Add(typeof(Foo), new XmlAttributes { XmlRoot = new XmlRootAttribute("foo") });
            overrides.Add(typeof(Foo), "Bar", new XmlAttributes { XmlAttribute = new XmlAttributeAttribute("bar") });
            var serializer = new XmlSerializer(typeof(Foo), overrides);
            using (var reader = XmlReader.Create("test.xml"))
            {
                var foo = (Foo)serializer.Deserialize(reader);
                Console.WriteLine(foo.Bar);
            }
        }
    }
