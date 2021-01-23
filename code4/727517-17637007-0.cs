    class Program
        {
            static void Main(string[] args)
            {
                //Create new instances of the Employee class
                Employee joe = new Employee("joe", 1);
                Employee billy = new Employee("billy", 2);
    
                Console.WriteLine(Employee.EmployeeCount);
            }
    
        }
    
        class Employee
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public static int EmployeeCount { get; set; }
    
            public Employee(string n, int id)
            {
                this.ID = id;
                this.Name = n;
                EmployeeCount++;
            }
        }
