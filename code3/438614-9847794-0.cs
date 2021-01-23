    public IList<T> GetAll()
    {
        using (var session = SessionProvider.OpenSession())
        {
            if (typeof(ISetDeleted).IsAssignableFrom(typeof(T)))
            {
                return session.Query<T>().Where(o => !(ISetDeleted) o).Deleted).ToList();
            }
            else 
            {
                return session.Query<T>().ToList(); 
            }
        }
    }
