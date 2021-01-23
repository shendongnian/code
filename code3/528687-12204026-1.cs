    var classMetadata = sessionfactory.GetClassMetadata(obj.GetType());
    object id;
    if (classMetadata.IdentifierType.IsComponentType)
        id = obj;
    else
        id = classMetadata.GetIdentifier(obj, NHibernate.EntityMode.Poco);
    fromDatabase = session.Get(classMetadata.EntityName, obj);
    if (fromDatabase != null)
        // already exists
