    public class PersonRepository
    {
        public PersonRepository(IDbConnection iGetInjected)
        {
        }
    
        public Person Get(int id)
        {
            // I create and return a person
            // using the connection to generate and execute a command
        }
    }
