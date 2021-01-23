    //Test person class
    internal class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }
    }
    //Test attribute class
    [AttributeUsage(AttributeTargets.All)]
    internal class TestAttribute : Attribute
    {
        public IEnumerable<Person> Something { get; set; }
    }
    //This won't work as Person is not an integral type
    [TestAttribute(Something = new Person[]{new Person("James")})]
