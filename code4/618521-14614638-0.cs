    public abstract class Employee
    {
        public string Name { get; private set; }
        public Employee(string name)
        {
            Name = name;
        }
    }
    public class Manager : Employee
    {
        public Manager(string name)
            : base(name)
        {
        }
    }
    public class Peon: Employee
    {
        public Peon(string name)
            : base(name)
        {
        }
    }
