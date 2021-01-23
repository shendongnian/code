    public class MyContext: DbContext, IUnitOfWork
    {
        public IDbSet<Note> Notes { get; set; }
        public IDbSet<DomainType> DomainTypes { get; set; }
        public IDbSet<DomainValue> DomainValues { get; set; }
        public IDbSet<Party> Parties { get; set; }
        public MyContext() :base()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
