    [XmlType(TypeName = "Response")]    
    public class ResponseObject
    {
        [XmlAttribute("status")]        
        public string file { get; set; }
        
        [XmlElement("Student", Type = typeof(Student))]
        public List<Student> studentList { get; set; }
    }
