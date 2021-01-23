    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; set; }
        public Telephone Telephone { get; set; }
        public Address Address { get; set; }
    
        public Person(string firstName, string lastName)
        {
            //do null-checks
            FirstName = firstName;
            LastName = lastName;
        }
    }
