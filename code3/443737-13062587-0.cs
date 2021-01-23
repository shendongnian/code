    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return string.Format("Firstname: {0}, Lastname: {1}", FirstName, LastName);
        }
    }
