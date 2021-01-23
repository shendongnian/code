    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Teacher : Person
    {
        public string ClassName { get; set; }
    }
    
    public class Student : Person
    {
        public int NumberOfClasses { get; set; }
    }
