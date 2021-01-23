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
                People people = null;
                XmlSerializer serializer = new XmlSerializer(typeof(People));
                using (StreamReader reader = new StreamReader("people.xml"))
                {
                    people = (People)serializer.Deserialize(reader);
                }
                people.person[0].Name = "Dan";
                using (StreamWriter writer = new StreamWriter("people.xml"))
                {
                    serializer.Serialize(writer, people);
                }
            }
        }
    }
