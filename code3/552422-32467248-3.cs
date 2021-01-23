    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get { return "Smith"; } set { FirstName = value; } }
        public Address Address { get; set; }
    }
