    enum Gender
    {
        Male = 0,
        Female = 1
    }
    class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public Person(string name, Gender gender, string country)
        {
            this.Name = name;
            this.Gender = gender;
            this.Country = country;
        }
    }
