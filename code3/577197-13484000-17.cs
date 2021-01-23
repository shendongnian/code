    public class Course
    {
      public int ID { set;get;}
      public string CourseName { set;get;}
      public List<Student> Students { set;get;}
      public Course()
      {
        Students=new List<Student>();
      }
    }
    public class Student
    {
      public int ID { set;get;}
      public string FirstName { set;get;}
    }
