    using System;
    using System.Linq;
    
    class Employee
    {
        public string Name { get; set; }
            public decimal Salary { get; set; }
    }
    
    public class Test
    {
        public static void Main()
        {
            Employee[] emps = new Employee[] 
            {
                new Employee { Name = "John", Salary = 9 },
                new Employee { Name = "Paul", Salary = 8 },
                new Employee { Name = "George", Salary = 6 },
                new Employee { Name = "Ringo", Salary = 6 }
            };
            decimal minSalary = emps.Min(x => x.Salary);
   
            foreach(var e in emps.Where(e => e.Salary == minSalary))
                Console.WriteLine("{0} {1}", e.Name, e.Salary);
        }
    }
