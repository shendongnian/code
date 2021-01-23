    public abstract class AbstractNHibernateDao<T, TIdT> 
        : IDao<T, TIdT> where T : class
    {
        public T SaveOrUpdateCopy(T entity)
        {
            NHibernateSession.Merge(entity);
            return entity;
        }
    }
