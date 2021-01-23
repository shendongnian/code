    using (var tx = session.BeginTransaction())
    {
        id = session.Save(new Entity());
        tx.Commit();
    }
    session.Clear();
    var entity = session.Get<Entity>(id);
    Console.WriteLine(entity.Component == null);
