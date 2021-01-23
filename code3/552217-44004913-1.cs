             public  class Employee  
            {  
                public string Name { get; set; }  
                public int Id { get; set; }  
                public string Department { get; set; }  
                public int salary { get; set; }  
            }  
            class Program  
            {  
                static void Main(string[] args)  
                {  
                    Employee emp=new Employee();  
                    emp.Name = "Kumar";  
                    emp.Department = "IT";  
                    emp.Id = 101;  
                    emp.salary = 80000;  
                    Console.ReadLine();  
              
                }  
            } 
          
    
