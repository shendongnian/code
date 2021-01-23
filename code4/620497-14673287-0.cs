    using (ISession session = SessionFactory.OpenSession())
    {
        session.CreateSQLQuery("USE OtherDatabase").ExecuteUpdate();
        // ...
    }
