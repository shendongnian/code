    [XmlRoot("employee")]
    public class Employee {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("nationality")]
        public string Nationality { get; set; }
    }
    void Main() {
        // ...
        var serializer = new XmlSerializer(typeof(Employee));
        var emp = new Employee { /* properties... */ };
        using (var output = /* open a Stream or a StringWriter for output */) {
            serializer.Serialize(output, emp);
        }
    }
