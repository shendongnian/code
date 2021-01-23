    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Person()
        {
        }
        public Person(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Erik", 16, "United States");
            Person p2 = new Person();
            p2.Name = "Erik";
            p2.Age = 16;
            p2.Country = "United States"; 
        }
    }
