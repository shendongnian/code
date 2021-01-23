    public class Student
    {
        [XmlElement("Id")]
        public int StudentID { get; set; }
        [XmlElement("Name")]
        public string StudentName { get; set; }
        [XmlElement("Section")]
        public int Section { get; set; }
    }
    [XmlRoot("School")]
    public class School
    {
        [XmlElement("Student", typeof(Student))]
        public List<Student> StudentList { get; set; }
    }
	
