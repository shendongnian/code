    public class Student
        {
            public string name { get; set; }
            public string course { get; set; }
            public DateTime bday { get; set; }
    
            public Student(string name, string course)
            {
                this.name = name;
                this.course = course;
            }
    
            public Student(string name, string course, DateTime bday)
            : this(name, course)
            {
                this.bday = bday;
            }
    }
