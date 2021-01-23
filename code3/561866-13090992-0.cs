    using System;
    using System.Xml.Serialization;
    public class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(XMLObject<MyElement>),
                    XMLObject<MyElement>.Overrides);
            serializer.Serialize(Console.Out,
                new XMLObject<MyElement>() { SomeElement = "value" });
            Console.ReadLine();
        }
    }
    public class XMLObject<T> where T : ElementTypeBase, new()
    {
        public static XmlAttributeOverrides Overrides { get; private set; }
        static XMLObject()
        {
            Overrides = new XmlAttributeOverrides();
            Overrides.Add(typeof(XMLObject<T>), "SomeElement",
                new XmlAttributes
                {
                    XmlElements =
                    {
                        new XmlElementAttribute(new T().ElementName)
                    }
                });
        }
        public string SomeElement { get; set; }
    }
    public abstract class ElementTypeBase
    {
        public abstract string ElementName { get; }
    }
    public class MyElement : ElementTypeBase
    {
        public override string ElementName
        {
            get { return "ElementA"; }
        }
    }
