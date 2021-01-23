    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        internal Person { }
    }
    public class PersonFactory
    {
        public NameSetter CreatePerson()
        {
            return new NameSetter(new Person());
        }
    }
    public class NameSetter
    {
        private Person person;
        internal NameSetter(Person person)
        {
            this.person = person;
        }
        public AgeSetter SetName(string name)
        {
            person.Name = name;
            return new AgeSetter(this.person);
        }
    }
    public class AgeSetter
    {
        private Person person;
        internal AgeSetter(Person person)
        {
            this.person = person;
        }
        public Person SetAge(int age)
        {
            this.person.Age = age;
            return this.person;
        }
    }
    public class Program
    {
        public void Main()
        {
            Person p = new PersonFactory().CreatePerson().SetName("Bob").SetAge(30);
        }
    }
