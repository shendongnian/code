    [XmlElement]
    public class Response
    {
        [XmlElement]
        bool Result;
        public tbl[] Table;
    }
    public class tbl
    {
        public Student[] Students;
    }
    
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        [XmlElement(ElementName = "GroupId")]    
        public int GrpId { get; set; }
    }
