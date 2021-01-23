    //I can set up a basic Repository pattern handling any IDomainObject...
    public interface IRepository<T> where T:IDomainObject
    {
        public TDom Retrieve<TDom>(int id) where TDom:T;
    }
    //... Then create an interface specific to a sub-domain for implementations of
    //a Repository for that specific persistence type
    public interface IDatabaseRepository:IRepository<T> where T:IDatabaseDomainObject
    {
        public TDom Retrieve<TDom>(int id) where TDom:T;
    }
