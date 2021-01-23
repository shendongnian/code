    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    using NUnit.Framework;
    
    namespace Serialization
    {
        [XmlRoot("Settings")]
        public class SerializableClass
        {
            public SerializableClass() { }
    
            [XmlElement("PropertyOne")]
            public String PropertyString { get; set; }
    
            [XmlElement("PropertyTwo")]
            public int PropertyInt { get; set; }
    
            public Object PropertyObject { get; set; }
    
            public String SerializeMe()
            {
                var serializer = new XmlSerializer(typeof(SerializableClass));
                var writer = new StringWriter();
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
    
            public static SerializableClass DeSerialize(String input)
            {
                var reader = new StringReader(input);
                var serializer = new XmlSerializer(typeof(SerializableClass));
                return serializer.Deserialize(reader) as SerializableClass;
            }
        }
    
        [TestFixture]
        public class SerializerTest
        {
            [Test]
            public void SerializationTest()
            {
                var serializableClass = new SerializableClass { PropertyInt = 23, PropertyString = "foo", PropertyObject = "bar"};
                Console.WriteLine(serializableClass.SerializeMe());
            }
    
            [Test]
            public void DeserializationTest()
            {
                var deserializedXML = @"<?xml version=""1.0"" encoding=""utf-16:""?>" +
                                        @"<Settings xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">" +
                                        @"<PropertyOne>foo</PropertyOne><PropertyTwo>23</PropertyTwo><PropertyObject xsi:type=""xsd:string"">bar</PropertyObject></Settings>";
                var serializableClass = SerializableClass.DeSerialize(deserializedXML);
                Console.WriteLine(serializableClass.PropertyInt);
                Console.WriteLine(serializableClass.PropertyString);
                Console.WriteLine(serializableClass.PropertyObject);
            }
        }
    }
