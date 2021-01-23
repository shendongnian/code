    class Employee
    {
         public Employee(string name)
         {
             Name = name;
         }
    
         private string m_name;
    
         public string Name
         {
             get { return m_name; }
             protected set { m_name = value; }
         }
         public void ChangeName(string name)
         {
             Name = name;
         }
    }
    
    static class MainClass
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Scott Chamberlain");
        
            Console.WriteLine(employee.Name) //Displays Scott Chamberlain;
        
            //employee.Name = "James Jeffery"; //Has a complier error if uncommented because Name is not writeable to MainClass, only members of Employee can write to it.
    
            employee.ChangeName("James Jeffery");
    
            Console.WriteLine(employee.Name) //Displays James Jeffery;
        }
    }
