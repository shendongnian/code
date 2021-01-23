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
