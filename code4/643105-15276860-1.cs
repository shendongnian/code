    using SharpRepository.Repository;
    public class PersonManager()
    {
        private IRepository<Domain.PersonIdentifier, int> personIdentifierRepository;
        private IRepository<Domain.NextNumber, string> nextNumberRepository;
        public PersonManager(DbContext dbContext)
        {
            this.personIdentifierRepository = new Ef5Repository<Domain.PersonIdentifier, int>(dbContext);
            this.nextNumberRepository = new Ef5Repository<Domain.NextNumber, string>(dbContext);
        }
    }
