    public IList<T> GetAll()
    {
        using (var session = SessionProvider.OpenSession())
        {
            var query = session.Query<T>();
    
            if (typeof(ISetDeleted).IsAssignableFrom(typeof(T)))
            {
                query = query.Where(x => !(ISetDeleted)x).Deleted);
            }
    
            return query.ToList(); 
        }
    }
