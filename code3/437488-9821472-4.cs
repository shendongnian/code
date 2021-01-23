    public interface IRepository<T> {}
    
    public class NHibernateRepository<T> : IRepository<T>
    {
        private ISession session;
    
        public NHibernateRepository(ISession session)
        {
            this.session = session;
        }
    
        T Get(object id) { return session.GetById<T>(id)); }
    
        IQueryable<T> Query { get { return session.Query<T>(); }
    }
    
    new NHibernateRepository<Customer>(session).Query().Where(customer => customer.Name == Fred);
