    using (var tx = session.BeginTransaction())
    {
        id = session.Save(new Entity());
        tx.Commit();
    }
    var entity = session.Get<Entity>(id);
    Console.WriteLine(entity.Component == null);
