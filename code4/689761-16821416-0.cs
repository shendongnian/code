    public class Person
    {
        public Address Address { get; set; }
        public Name Name { get; set; }
        public int Age { get; set; }
    }
    public class Address
    {
        public string Place { get; set; }
        public Name ParentName { get; set; }
    }
    public class Name
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
