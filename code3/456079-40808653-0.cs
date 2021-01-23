    namespace Reflection
    {
        using System;
    
        class Person
        {
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
    
            public virtual void Print()
            {
                Console.WriteLine("Name: {0} {1}", FirstName, LastName);
            }
        }
    }
    namespace Reflection
    {
        using System;
    
        class Employee : Person
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
