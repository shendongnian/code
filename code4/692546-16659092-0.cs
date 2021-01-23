    MyEntity myEntity;
    using(var scope = new TransactionScope(TransactionScopeOption.Suppress))
    using(var session = sessionFactory.OpenSession())
    {
        myEntity = session.Get<MyEntity>(id);
        scope.Complete();
    }
    // No longer in a transaction...
    myEntity.Add(something);
    myEntity.Update(somethingElse);
    // Later, possibly in another request...
    using(var scope = new TransactionScope(TransactionScopeOption.Required))
    using(var session = sessionFactory.OpenSession())
    {
        session.Update(myEntity);
        scope.Complete();
    }
