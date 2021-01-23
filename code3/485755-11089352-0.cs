    namespace XmlTestApp
    {
        [XmlRoot("XmlTestApp:Student")]
        public class Student
        {
            private string studentId;
    
            public string FirstName;
            public string MI;
            public string LastName;
    
            public Student()
            {
                //Just provided for making Serialization work as obj.GetType() needs parameterless constructor.
            }
    
            public Student(String studentId)
            {
                this.studentId = studentId;
            }
    
        }
    }
