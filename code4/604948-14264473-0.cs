    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace Test
    {
    
        public class TestXML
        {
            public DecimalValue TestDecimal;
            public IntegerValue TestInteger;
        }
    
        public class IntegerValue
        {
            [XmlText]
            public int value {get; set;}
            [XmlAnyAttribute]
            public XmlAttribute[] XAttributes {get; set;}
        }
    
        public class DecimalValue
        {
            [XmlText]
            public decimal value {get; set;}
            [XmlAnyAttribute]
            public XmlAttribute[] XAttributes {get; set;}
        }
    
        class Program
        {
    
            static void Test()
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TestXML));
                using (FileStream fs = new FileStream("Test.xml", FileMode.Open)) 
                {
                    TestXML myxml = (TestXML)serializer.Deserialize(fs);
                }
                
            }
    
            static void Main(string[] args)
            {
                Test();
            }
        }
    }
