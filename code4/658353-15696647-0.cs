    public interface Person
    {
        string Name { get; set; }
    }
    
    public class Manager : Person
    {
        public string Name { get; set; }
    }
    
    public class Employee : Person
    {
        public string Name { get; set; }
        public string ManagerName { get;set;}
    }
