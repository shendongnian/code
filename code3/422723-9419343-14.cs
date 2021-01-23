    public class PersonsRepository : IRepository<Person>
    {
        private DataContext dc;
        public PersonsRepository(DataContext dataContext)
        {
            dc = dataContext;
        }
        public void Create(Person Person)
        {
            dc.Persons.Add(Person);
        }
        public IQueryable<Person> Retrieve()
        {
            IQueryable<Person> Person = (from s in dc.Persons
                                           select s);
            return Person.AsQueryable();
        }
        public void Update(Person Person)
        {
            Person _Person = (from s in dc.Persons
                                where s.ID == Person.ID
                                select s).Single();
            {
                _Person.LastLogin = Person.LastLogin;
                _Person.Password = Person.Password;
                _Person.LastUpdate = Person.LastUpdate;
                // Cannot change your username.
            }
        }
        public void Delete(Person Person)
        {
            dc.Persons.Remove(Person);
        }
        public void SubmitChanges()
        {
            dc.SaveChanges();
        }
    }
