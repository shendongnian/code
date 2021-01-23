    **There are 3 main benifits of object Initializations-**
    
     - Avoid lot of keystrokes,The efficiency of software programs is sometimes measured by the number of keystrokes it requires to write a specific function.
    
     - Easy to readable and maintainable.
    
     - Time saving approach.
    
     Let see here how it can avoid lot of keystrokes-
    Before c# 3.0 we were doing initialisation like this-
    
      
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
        
         
          
    
    Now after c# 3.0 we will initialise in one line as follow.
   
    class Program  
        {  
            static void Main(string[] args)  
            {  
                Employee emp = new Employee {Name = "Kisan",Id = 55,Department = "IT",salary = 20000};  
      
      
            }  
        }  
    
