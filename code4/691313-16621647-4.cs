    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    public class Person
    {
        public string Name { get; set; }
    }
    
    public class PersonWrapper : IXmlSerializable
    {
        public Person Person { get; set; }
        
        public static implicit operator Person(PersonWrapper wrapper)
        {
            return wrapper == null ? null : wrapper.Person;
        }
        
        public static implicit operator PersonWrapper(Person person)
        {
            return new PersonWrapper { Person = person };
        }
        
        public XmlSchema GetSchema()
        {
            return null;
        }
        
        public void ReadXml(XmlReader reader)
        {
            string name = reader.ReadString();
            reader.ReadEndElement();
            Person = new Person { Name = name };
        }
        
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Person.Name);
        }
    }
    
    public class Company
    {
        [XmlElement(typeof(PersonWrapper))]
        public Person Director { get; set; }
    
        [XmlElement(typeof(PersonWrapper))]
        public Person Manager { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(Company));
            
            var original = new Company
            {
                Director = new Person { Name = "Holly" },
                Manager = new Person { Name = "Jon" }
            };
            
            var writer = new StringWriter();
            serializer.Serialize(writer, original);
            Console.WriteLine("XML:");
            Console.WriteLine(writer.ToString());
            
            var reader = new StringReader(writer.ToString());
            var deserialized = (Company) serializer.Deserialize(reader);
            
            Console.WriteLine("Deserialized:");
            Console.WriteLine("Director: {0}", deserialized.Director.Name);
            Console.WriteLine("Manager: {0}", deserialized.Manager.Name);
        }
    }
