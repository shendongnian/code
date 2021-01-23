    public class Class
    {
      public string Name
      {
        get;
        set;
      }
      public Collection<Student> Students
      {
        get;
        set;
      }
      public Class( string name, Collection<Student> students )
      {
        this.Name = name;
        this.Students = students;
      }
    }
    public class Student
    {
      public string Name
      {
        get;
        set;
      }
      public string FirstName
      {
        get;
        set;
      }
      public string Fullname
      {
        get
        {
          return string.Format( "{0}, {1}", this.Name, this.FirstName );
        }
      }
      public Student(string name, string firstname)
      {
        this.Name = name;
        this.FirstName = firstname;
      }
    }
