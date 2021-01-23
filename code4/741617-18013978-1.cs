       public class Student 
       {
          public int StudentId { get; set; }
          public int StudentName { get; set; }
          public int StudentRoll { get; set; }
    
          public int DepartmentId { get; set; }
          public virtual Department Department { get; set; }
       }
       public class Department 
       {
          public int DepartmentId { get; set; }
          public int DepartmentName { get; set; }
    
          public virtual ICollection<Student> Students { get; set; } 
       }
