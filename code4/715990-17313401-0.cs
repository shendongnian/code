      using (var session = sessionFactory.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
           ... code to get a person
           transaction.Commit();
        }
      }
