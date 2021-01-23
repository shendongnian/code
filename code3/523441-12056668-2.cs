    class PersonInfo
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public Color? FavoriteColor { get; set; }
        public Person BuildPerson()
        {
            return new Person(this);
        }
    }
    
    class Person
    {
        public Person(PersonInfo info)
        {
            // use info and handle optional/nullable parameters to initialize person
        }
        ...
    }
    var p = new Person(new PersonInfo { Name = "Peter", Age = 15 });
    // yet better
    var p = new PersonInfo { Name = "Peter", Age = 15 }.BuildPerson();
