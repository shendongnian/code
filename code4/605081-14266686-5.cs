    public class Student
    {
         public string Name {get;set;}
         public List<string> Subjects {get;set;}
         public Student(string name, List<string> subjects)
         {
             Name = name;
             Subjects = subjects;
         }
    }
