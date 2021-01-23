       using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class Employee
        {
            public string Name { get; set; }
        }
    
        class MyClass
        {
            public Employee EmpObj;
    
            public void SetObject(Employee obj)
            {
                EmpObj = obj;
            }
        }
    
        public class Program
        {
           static void Main(string[] args)
            {
                Employee someTestObj = new Employee();
                someTestObj.Name = "ABC";
    
                MyClass cls = new MyClass();
                cls.SetObject(someTestObj);
                // 
                Console.WriteLine("Changing Emp Name To xyz");
                someTestObj.Name = "xyz";
               //
                Console.WriteLine("Accessing Assigned Emp Name");
                Console.WriteLine(cls.EmpObj.Name); 
     
               Console.ReadLine();
           }       
        }
}
 
