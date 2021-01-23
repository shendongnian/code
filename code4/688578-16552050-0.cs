    var metaData = this.session.SessionFactory.GetClassMetadata(typeof(A));
    foreach(IType propertyType in metaData.PropertyTypes)
    {
      if(propertyType.IsCollectionType)
      {
        var name = propertyType.Name;
      }
    }
