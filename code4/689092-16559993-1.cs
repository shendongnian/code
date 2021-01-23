    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    
        // Paramterless constructor  -  for   new Person();
        // All properties get their default values (string="" and int=0)
        public Person () { }
        // Parameterized constructor -  for   new Person("Joe", 16, "USA");
        public Person (string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
    }
