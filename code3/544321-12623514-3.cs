    using System.Xml.Serialization;
    ...
    // TODO: Move the namespace name to a const variable
    [XmlRoot(ElementName = "Person", Namespace = "http://api.google.com/staticInfo/")]
    public class Person
    {
        [XmlElement(ElementName="Id", Namespace="http://api.google.com/staticInfo/")]
        public int ID { get; set; }
        [XmlElement(ElementName = "age", Namespace = "http://api.google.com/staticInfo/")]
        public int Age { get; set; }
    }
    ...
    string input =
        @"<g1:Person xmlns:g1=""http://api.google.com/staticInfo/"">
            <g1:Id>005008</g1:Id>
            <g1:age>23</g1:age>
          </g1:Person>";
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
    Person person = (Person)xmlSerializer.Deserialize(new StringReader(input));
