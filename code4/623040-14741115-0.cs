    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
    
        [XmlRoot("people")]
        public class People
        {
            [XmlElement("person")]
            public Person[] person { get; set; }
        }
    
        [Serializable]
        public class Person
        {
            [XmlElement("name")]
            public string Name { get; set; }
        }
    
        class Program
        {
            public static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(People));
                StreamReader reader = new StreamReader("people.xml");
                People people = (People)serializer.Deserialize(reader);
            }
        }
    }
