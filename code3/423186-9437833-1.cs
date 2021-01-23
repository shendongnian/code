    public class Business
    {
        public string Name { get; set; }
        public ICustomerRoles CustomerRoles { get; set; }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Comments { get; set; }
        public ICustomerRoles CustomerRoles { get; set; }
    }
