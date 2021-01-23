    using System;
    using System.Linq;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                printEmployeeBaseClassProperties();
            }
            
            static void printEmployeeBaseClassProperties()
            {
                // Employee (derived class) - Person (base class)
                var employee = new Employee
                {
                    Company = "Stack Overflow",
                    Designation = "Community Manager",
                    FirstName = "Josh",
                    LastName = "Heyer"
                };
    
                var baseType = employee.GetType().BaseType;
                var properties = baseType.GetProperties();
                var method = baseType.GetMethod("Print");
                
                for (var i = 0; i < properties.Count(); i++)
                {
                    Console.WriteLine(properties[i].Name);
                }
    
                Console.WriteLine();
                method.Invoke(employee, null);
            }
        }
        
        public class Person
        {
            public string FirstName { get; set; }
            
            public string LastName { get; set; }
            
            public virtual void Print()
            {
                Console.WriteLine("Name: {0} {1}", FirstName, LastName);
            }
        }
    
        public class Employee : Person
        {
            public string Company { get; set; }
            
            public string Designation { get; set; }
            
            public override void Print()
            {
                base.Print();
                Console.WriteLine("Employment Details: {0} {1}", Company, Designation);
            }
        }
    }
