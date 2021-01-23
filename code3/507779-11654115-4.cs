    public class School
    { 
       public int SchoolId {get; set;} 
       public string Schoolname {get; set;} 
       public int StateId {get; set;} 
       public virtual IList<Student> Students {get; set; }
    } 
