    public interface IFoo : IXmlSerializable
    {
        // anothers properties...
        object Value { get; }
    }
    [XmlRoot("Foo")]
    public class FooA : IFoo
    {
        public string Value { get; set; }
        object IFoo.Value { get { return Value; } }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Foo");
            writer.WriteStartAttribute("Type", "http://example.com/2007/ns1");
            writer.WriteString(GetType().Name);
            writer.WriteEndAttribute();
            
            writer.WriteStartAttribute("Value");
            writer.WriteString(Value.ToString());
            writer.WriteEndAttribute();
            writer.WriteEndElement();
        }
        #endregion
    }
    [XmlRoot("Foo")]
    public class FooB : IFoo
    {
        public int Value { get; set; }
        object IFoo.Value { get { return Value; } }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Foo");
            writer.WriteStartAttribute("Type", "http://example.com/2007/ns1");
            writer.WriteString(GetType().Name);
            writer.WriteEndAttribute();
            writer.WriteStartAttribute("Value");
            writer.WriteString(Value.ToString());
            writer.WriteEndAttribute();
            writer.WriteEndElement();
        }
        #endregion
    }
    [XmlRoot("Foo")]
    public class FooC : IFoo
    {
        public List<double> Value { get; set; }
        object IFoo.Value { get { return Value; } }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Foo");
            writer.WriteStartAttribute("Type", "http://example.com/2007/ns1");
            writer.WriteString(GetType().Name);
            writer.WriteEndAttribute();
            writer.WriteStartElement("Value");
            if (Value != null)
            {
                writer.WriteStartElement("List");
                writer.WriteStartAttribute("Type", "http://example.com/2007/ns1");
                writer.WriteString(typeof(double).Name);
                writer.WriteEndAttribute();
                foreach (double value in Value)
                {
                    writer.WriteElementString("Element", value.ToString());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        #endregion
    }
    [XmlRoot("Foos")]
    public class ListCotainer : List<IFoo>, IXmlSerializable
    {
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("xmlns", "xsi", null, "http://example.com/2007/ns1");
            foreach (IFoo foo in this)
            {
                foo.WriteXml(writer);
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriterSettings _xws = new XmlWriterSettings();
            _xws.OmitXmlDeclaration = true;
            _xws.ConformanceLevel = ConformanceLevel.Auto;
            _xws.Indent = true;
            ListCotainer container = new ListCotainer()
            {
                    new FooA() { Value = "String" },
                    new FooB() { Value = 2 },
                    new FooC() { Value = new List<double>() {2, 3.4 } } 
            };
            StringBuilder xmlString = new StringBuilder();
            using (XmlWriter xtw = XmlTextWriter.Create(xmlString, _xws))
            {
                XmlSerializer serializer = new XmlSerializer(container.GetType());
                serializer.Serialize(xtw, container);
                xtw.Flush();
            }
            Console.WriteLine(xmlString.ToString());
        }
    }
