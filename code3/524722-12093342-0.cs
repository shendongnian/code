        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Xml.Serialization;
    
        namespace XMLSer
        {
            class Program
            {
                static void Main(string[] args)
                {
                    FName fname = new FName { Age = 16.5, Text = "John" };
    
                Person person = new Person();
    
                person.fname = fname;
                person.lname = "Wayne";
    
                XmlSerializer ser = new XmlSerializer(typeof(Person));
                ser.Serialize(Console.Out, person);
                Console.ReadKey();
            }
        }
    
        [XmlRoot(ElementName = "person")]
        public class Person
        {
            [XmlElement(Namespace = "http://example.com")]
            public FName fname;
    
            [XmlElement(Namespace = "http://sample.com")]
            public string lname;
    
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
    
            public Person()
            {
                xmlns.Add("a", "http://example.com");
                xmlns.Add("b", "http://sample.com");
            }
        }
    
        public class FName
        {
            [XmlAttribute("age")]
            public double Age;
    
            [XmlText]
            public string Text;
        }
    }
