    if (sessionfactory.GetClassMetadata(obj.GetType()).IdentifierType.IsComponentType)
        fromDatabase = session.Get(obj);
    else
        fromDatabase = session.Get(sf.GetClassMetadata(obj.GetType()).GetIdentifier(obj, NHibernate.EntityMode.Poco));
    if (fromDatabase != null)
        // already exists
