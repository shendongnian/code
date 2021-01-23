    public class Person
    {
        public string Name { get; set; }
    
        public Person() {};
        public Person( Person rhs ) 
        {
            Name = rhs.Name;
        }
    }
    
    public class Customer : Person
    {
        private string m_role = "Customer";
        public string Role { get m_role; }
    
        public Customer() : base();
    }
    
    public class Employee : Person
    {
        private string m_role = "Employee";
        public string Role { get m_role; }
    
        public Employee() : base();
    }
