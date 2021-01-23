    try {
        session.Save(entity);  // has duplicate key
    } catch {}
    Assert(entity.Id, Key.Unsaved);
    session.SaveOrUpdate(entity2); // will issue INSERT and throws again
