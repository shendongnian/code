    public class PersonsService
    {
        private PersonRepository<Person> personRepository;
    
        public PersonService()
        {
            personRepository = new PersonRepository<Person>();
        }
    
        public UsablePerson GetPersonByID(int ID)
        {
            Person person = (from p in personRepository<Person>.Retrieve
                                   where p.ID = ID
                                   select p).FirstOrDefault();
            UsablePerson uPerson;
            // use something like AutoMapper to map person to uPerson
            // alternatively you do it manually like this
            uPerson.FirstName = person.FirstName;
            uPerson.LastName = person.LastName;
            uPerson.EmailAddress = person.Email; // notice the different property name.
            return uPerson;
    
        }
    }
