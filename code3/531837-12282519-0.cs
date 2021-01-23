    public class StudentDictionary
    {
      private readonly Dictionary<int, Student> _byId = new Dictionary<int, Student>();
      private readonly Dictionary<string, Student> _byUsername = new Dictionary<string, Student>();//use appropriate `IEqualityComparer<string>` if you want other than ordinal string match
      public void Add(Student student)
      {
        _byId[student.ID] = student;
        _byUsername[student.Username] = student;
      }
      public bool TryGetValue(int id, out Student student)
      {
        return _byId.TryGetValue(id, out student);
      }
      public bool TryGetValue(string username, out Student student)
      {
        return _byUsername.TryGetValue(username, out student);
      }
    }
