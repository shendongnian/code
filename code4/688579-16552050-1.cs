    A instance = ...
    var metaData = this.session.SessionFactory.GetClassMetadata(instance.GetType());
    foreach(IType propertyType in metaData.PropertyTypes)
    {
      if(propertyType.IsCollectionType)
      {
        var name = propertyType.Name;
        var collectionType = (NHibernate.Type.CollectionType)propertyType;
        var collection = collectionType.GetElementsCollection(instance);
        bool hasAny = collection.Count > 0;
      }
    }
