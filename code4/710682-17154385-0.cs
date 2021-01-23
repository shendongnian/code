    var someAssembly = typeof(Foo).Assembly; // Or whatever
    var values = from type in someAssembly.GetTypes()
                 from field in type.GetFields(BindingFlags.Static |
                                              BindingFlags.Public |
                                              BindingFlags.NonPublic)
                 where field.IsInitOnly &&
                       field.FieldType == typeof(LocalisationToken)
                 select (LocalisationToken) field.GetValue(null);
  
