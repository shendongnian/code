    //Initialize collections
    FieldInfo[] properties = type.GetFields(BindingFlags.DeclaredOnly 
                                          | BindingFlags.NonPublic 
                                          | BindingFlags.Instance);
    foreach (FieldInfo f in properties)
    {
       if(typeof(IList<int>).IsAssignableFrom(f.FieldType)
       && f.GetValue(obj) == null)
       {
             object value = Container.Resolve(f.FieldType);
             f.SetValue(obj, value);
       }
    }
