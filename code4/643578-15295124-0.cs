    using (var session = SessionFactory.OpenSession())
    {
      using (var tx = session.BeginTransaction())
      {
          var entity = session.Get<Entity>(id);
          entity.Property1 = "new value";
          entity.Property2 = "new value";
          tx.Commit();
      }
    }
