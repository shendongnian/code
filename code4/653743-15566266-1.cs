    public virtual IList<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            // Open NHibernate Session
            using (var session = NHibernateHelper.OpenSession())
                return (predicate != null
                           ? session.Query<T>().Where(predicate)
                           : session.Query<T>()).ToList();
    
        }
