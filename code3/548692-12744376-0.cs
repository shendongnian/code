- Inheritance from the abstract base class Employee
- Encapsulation / Polymorphism when we refer to the GetBonusMultiplier method. We are able to refer to the method from the abstract base class and we are also unaware of the internals of how each type determines the base multiplier. All we know / care is that when we call the method, we get an int value back.
If you wanted to change Employee to an interface IEmployee it would be simple. I would probably still have some kind of abstract base to capture the common fields though so you don't have to reimplement in each class that implements IEmployee.
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Manager(1, "Dave Smith"),
                new Director(2, "Peter Thompson")
            };
            foreach (Employee employee in employees)
            {
                Console.WriteLine(string.Format("Employee ID: {0}. Employee Name: {1}. Bonus Multiplier: {2}.", employee.Id, employee.Name, employee.GetBonusMultiplier()));
            }
            Console.ReadKey();
        }
    }
    abstract class Employee
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public abstract int GetBonusMultiplier();
    }
    class Director : Employee
    {
        public Director(int employeeId, string name)
        {
            Id = employeeId;
            Name = name;
        }
        public override int GetBonusMultiplier()
        {
            return 3;
        }
    }
    class Manager : Employee
    {
        public Manager(int employeeId, string name)
        {
            Id = employeeId;
            Name = name;
        }
        public override int GetBonusMultiplier()
        {
            return 2;
        }
    }
