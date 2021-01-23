      Person person
      using (var session = sessionFactory.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
           person = session.Get<Person>(1);
           transaction.Commit();
        }
      }
      var attrs = person.Attributes...
