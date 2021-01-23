    public class Student {
      public string FirstName { get; set; }
      public List<Course> Courses { get; set; }
      public Student() {
        this.Courses = new List<Course>();
      }
    }
    public class Course {
       public string Title { get; set; }
       public string Code { get; set; }
       public string Section { get; set; }
       public List<Assignment> Assignments { get; set; }
       public Course() {
         this.Assignments = new List<Assignment>();
       }
    }
    public class Assignment {
      public string Name { get; set; }
      public double MaxGrade { get; set; }
      public double StudentGrade { get; set; }
    }
