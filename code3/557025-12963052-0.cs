    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class PersonRepository()
    {
        public void Add(Person person)
        {
            // do some database stuff
        }
    }
    // ...
    
    Person person = new Person() { Name = "Jim", Address = "123 Fake Street" };
    
    PersonRepository personRepository = new PersonRepository();
    personRepository.Add(person);
