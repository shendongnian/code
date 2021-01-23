    public abstract class Person
    {
        public int PersonId     { get; set; }   // EF will set this as PK
        public string FirstName { get; set; }
        public string LastName  { get; set; }
    }
    [Table("User")]
    public class User : Person
    {
        public string SomeUserProperty { get; set; }
    }
    [Table("Employee")]
    public class Employee : Person
    {
        public string SomeEmployeeProperty { get; set; }
    }
