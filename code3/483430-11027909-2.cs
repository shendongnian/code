    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    static class Program
    {
        static void Main()
        {
            string xmlString = @"<rt>
      <el nm=""Name"" vl=""ABCD_test""/>
      <el nm=""Dual"" vl=""AA""/>
      <el nm=""Quad"" vl=""ABCD""/>
      <el nm=""YYMMDD"" vl=""120614""/>
    </rt>";
            XMLSessionParameters parameters = (XMLSessionParameters)Deserialize(typeof(XMLSessionParameters), xmlString);
            // parameters now has 4 elements, all correctly configured
        }
        private static object Deserialize(Type type, string XmlString)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            StringReader stringReader = new StringReader(XmlString);
            XmlReader xmlReader = new XmlTextReader(stringReader);
            object serializedObj = serializer.Deserialize(xmlReader);
            return serializedObj;
        }
    
    }
    
    [XmlRoot("rt")]
    public class XMLSessionParameters
    {
        [XmlElement("el")]
        public List<Elements> Elements { get; set; }
    }
    
    public class Elements
    {
        [XmlAttribute("nm")]
        public string Name { get; set; }
    
        [XmlAttribute("vl")]
        public string Value { get; set; }
    }
