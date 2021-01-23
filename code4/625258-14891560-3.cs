    object IFactoryProvider.GetInstance(Type type)
    {
      var useSpecial = ... // get the information to decide
      
      if (useDefault)
      {
        return Special.GetInstance(type);
      }
      else
      {
        return ObjectFactory.GetInstance(type);
      }
