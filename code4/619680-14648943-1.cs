    public IList<T> Query(Expression<Func<T, bool>> criteria)
    {
      using (var session = SessionProvider.SessionFactory.OpenSession())
      {
        return session.Query<T>().Where(criteria).ToList();
      }
    }
