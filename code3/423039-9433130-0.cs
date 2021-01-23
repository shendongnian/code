    var rep1 = new Repository<SomeEntity>(session);
    var rep2 = new Repository<SomeOtherEntity>(session);
    using (var tx = session.BeginTransaction())
    {
        try
        {
            rep1.Save(newSomeEntity);
            rep2.Save(SomeOtherEntity);
            tx.Commit();
        }
        catch (SomeException ex)
        {
            Handle(ex);
            tx.RollBack();
        }
    }
