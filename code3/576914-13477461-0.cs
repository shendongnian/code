       public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    
        public Person(string firstname, lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            AddPerson();
        }
    
        private void AddPerson()
        {
            string fn = this.Firstname;
            string ln = this.Lastname;
            // Do something with these values
            // Probably involves adding to a database
        }
    
    }
