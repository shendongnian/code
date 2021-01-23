    public class PersonsService
    {
        private PersonRepository<Person> personRepository;
    
        public PersonService()
        {
            personRepository = new PersonRepository<Person>();
        }
    
        public UsablePerson GetPersonByID(int ID)
        {
            UsablePerson person = (from p in personRepository<Person>.Retrieve
                                   where p.ID = ID
                                   select new UsablePerson { p.FirstName, 
                                                             p.LastName, 
                                                             p.EmailAddress }).FirstOrDefault();
            return person;
        }
    }
