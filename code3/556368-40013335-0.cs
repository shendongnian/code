    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class PersonWithBirthDate : Person
    {
        public DateTime DateOfBirth { get; set; }
    }
