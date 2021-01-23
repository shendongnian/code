    IList<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies();
    List<Type> allTypes = new List<Type>();
    foreach (Assembly assembly in assemblies)
    {
        var types = from t in assembly.GetTypes()
                    where bootStrapperType.IsAssignableFrom(t)
                        && !t.IsInterface && !t.IsAbstract
                    select t;
        allTypes.AddRange(types);
    }
    foreach(Type type in allTypes)
    {
        var fieldsPublic = type.GetFields(BindingFlags.Public|BindingFlags.Static);
        foreach(var field in fieldsPublic)
        {
           var nameAndValue = field.Name + " = " + field.GetValue(null);
           // Do something
        }
        var fieldsPrivate = type.GetFields(BindingFlags.Private|BindingFlags.Static);
        foreach(var field in fieldsPrivate)
        {
           var nameAndValue = field.Name + " = " + field.GetValue(null);
           // Do something.
        }
    }
