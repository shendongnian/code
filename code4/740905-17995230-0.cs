    // shared between repositories
    public interface IGenericRepository<T> 
    {
        T CreateNew();
        void Delete( T item );
        void Update( T item );
        void Insert( T item );
        IEnumerable<T> FindAll();
        T FindOne( int id );
    }
    // specific repositories
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        IEnumerable<Animal> FindByNumberOfLegs( int NumberOfLegs );
        // ... anything specific follows
    }
    public interface IHumanRepository : IGenericRepository<Human>
    {
        IEnumerable<Human> FindByGender( Gender gender );
        //  ... specific repository logic follows
    }
    // unit of work - a service for clients
    public interface IUnitOfWork : IDisposable
    {
        IAnimalRepository AnimalRepository { get; }
        IHumanRepository  HumanRepository { get; }
        // .. other repositories follow
        void SaveChanges(); 
    }
