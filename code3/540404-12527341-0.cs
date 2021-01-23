    using (NHibernate.ISession nhSession = User.OpenSession())
    using (var trans = nhSession.BeginTransaction())
    {
        User u = nhSession.Get<User>(id);
        // Now update non-identifier fields as you wish.
        // Since the instance is already known by NH, the following
        // is enough (with default NH settings) to persist the changes.
        trans.Commit();
    }
    return true;
