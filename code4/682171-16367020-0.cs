    public bool IsObjectADataMapper(DataMapperBase base) {
      var typeUnderTest = base.GetType();
      if (!typeUnderTest.IsGenericType())
        return false; // its not generic so it can't match
      var typeToTestFor = typeof(ObjectADataMapper<>);
      return typeToTestFor.Equals(typeUnderTest.GetGenericTyepDefinition());
    }
 
