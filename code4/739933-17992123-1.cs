    using (var session = NHibernateHelper.OpenSession())
    using (var tx = session.BeginTransaction())
    {
        session.Save(new Entity() { name = "Smith" });
        session.Save(new Entity() { name = "Smithers" });
        session.Save(new Entity() { name = "Smithery" });
        session.Save(new Entity() { name = "Smith" });
        tx.Commit();
    }
    String name_constant = "Smith";
    using (var session = NHibernateHelper.OpenSession())
    using (var tx = session.BeginTransaction())
    {
        var result = session.Query<Entity>().Cacheable().Count(e => e.name == name_constant);
    }
    using (var session = NHibernateHelper.OpenSession())
    using (var tx = session.BeginTransaction())
    {
        var result = session.Query<Entity>().Cacheable().Count(e => e.name == name_constant);
    }
