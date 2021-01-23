    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    namespace Logger
    {
        internal class Program
        {
            static List<Employee> employees = new List<Employee>()
            {
                new Employee{Name = "William", Age=30, RollNo=1234},
                new Employee{Name = "Martin", Age=29, RollNo=1235},
                new Employee{Name = "Richard", Age=28, RollNo=1236},
                new Employee{Name = "Baldwin", Age=27, RollNo=1237}
            };
            static void Main(string[] args)
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    WriteToLog();
                });
            }
            public static void WriteToLog()
            {            
                static string fileName = @"C:\ParallelLog.txt";
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    foreach (Employee employee in employees.AsParallel().AsOrdered())
                        writer.WriteLine("{0} - {1} - {2}", employee.Name, employee.Age, employee.RollNo);
                }
            }
        }
        internal class Employee
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public int RollNo { get; set; }
        } 
    }
    
