    namespace Reflection
    {
        using System;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                printEmployeeBaseClassProperties();
            }
    
            static void printEmployeeBaseClassProperties()
            {
                var employee = new Employee
                {
                    Company = "Stack Overflow",
                    Designation = "Community Manager",
                    FirstName = "Josh",
                    LastName = "Heyer"
                };
    
                var baseType = employee.GetType().BaseType;
                var properties = baseType.GetProperties();
                Console.WriteLine("Employee's base class properties are: ");
                Console.WriteLine("--------------------------------------");
                for (var i = 0; i < properties.Count(); i++)
                {
                    Console.WriteLine(properties[i].Name);
                }
    
                Console.WriteLine();
                Console.WriteLine("Print method invocation: ");
                method.Invoke(employee, null);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
            }
        }
    }
