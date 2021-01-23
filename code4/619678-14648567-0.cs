    public IList<T> Query(Func<T, bool> criteria)
    {
      using (var session = SessionProvider.SessionFactory.OpenSession())
      {
        return session.Query<T>().Where(criteria).ToList();
      }
    }
