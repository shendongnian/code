       public class Student
       {
           public Student()
           {
             Fees = new List<Fees>();
           }
    
            public int StudentID { get; set;}
            public string Name { get; set;}
            public List<Fee> Fees {get;set;}
        }
