            public class Student 
                { 
            public int ID {get;set;}
        public string Name {get; set;}
    
    public virtual ICollection<Course> Courses {get; set;}
    
    public Student()
    {
    Courses = New HashSet<Course>();
    }
                }
