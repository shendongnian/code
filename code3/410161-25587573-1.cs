    public class Customer : Person
    {
        private string m_role = "Customer";
        public string Role { get m_role; }
    
        public Customer() : base();
        public Customer( Person per ) : base( per);
    }
    
    public class Employee : Person
    {
        private string m_role = "Employee";
        public string Role { get m_role; }
    
        public Employee () : base();
        public Employee ( Person per) : base( per);
    }
 
