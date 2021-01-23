    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public Person() { }
        public Person(string id, string firstName, string lastName, 
                      string city, string country, string language)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.Country = country;
            this.Language = language;
        }
    }
