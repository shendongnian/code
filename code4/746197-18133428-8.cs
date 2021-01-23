    public class Employee
    {
        public Employee() 
        {
            this.Insurance = new Insurance();
        }
        // Perhaps another constructor for the name?
        public Employee(string name)
            : this()
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public Insurance Insurance { get; private set; }
    }
    
    public class Insurance
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
    }
