    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // this will be computed
        public string DisplayName { get; private set; }
    }
