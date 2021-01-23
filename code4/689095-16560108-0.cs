    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Person()
        {
        }
        public Person(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            var person1 = new Person();
            person1.Name = "Joe";
            person1.Age = 2;
            person1.Country = "USA";
            var person2 = new Person("John", 4, "USA");
        }
    }
