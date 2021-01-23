    namespace Reflection
    {
        using System;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                var developer = new Employee
                {
                    Company = "Stack Overflow",
                    Designation = "CEO",
                    FirstName = "Joel",
                    LastName = "Spolsky"
                };
    
                var engineer = new Employee
                {
                    Company = "Stack Overflow",
                    Designation = "Engineering",
                    FirstName = "Robert",
                    LastName = ""
                };
    
                printEmployeeBaseClassProperties();
    
                var isPersonInfoSpecified = IsPersonInfoSpecified(developer);
                developer.Print();
                Console.WriteLine("Is personal info specified: " + isPersonInfoSpecified);
                Console.WriteLine();
    
                isPersonInfoSpecified = IsPersonInfoSpecified(engineer);
                engineer.Print();
                Console.WriteLine("Is personal info specified: " + isPersonInfoSpecified);
                Console.WriteLine();
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
    
            static bool IsPersonInfoSpecified(Employee employee)
            {
                if (employee != null)
                {
                    var type = employee.GetType().BaseType;
                    var properties = type.GetProperties();
                    var methods = type.GetMethods();
                    // properties = properties.Where(p => p.DeclaringType.FullName == typeof(Person).FullName).ToArray();
                    // properties = properties.Where(p => p.DeclaringType.FullName == type.BaseType.FullName).ToArray();
    
                    if (properties.All(p => p.CanRead && !string.IsNullOrWhiteSpace(Convert.ToString(p.GetValue(employee, null)))))
                    {
                        return true;
                    }
                }
    
                return false;
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
