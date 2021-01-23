    Type type = typeof(T); 
    ConstructorInfo[] constructors = type.GetConstructors();
    // take one, for example the first:
    var ctor = constructors.FirstOrDefault();
    if (ctor != null)
    {
        ParameterInfo[] params = ctor.GetParameters();
        foreach(var param in params)
        {
             Console.WriteLine(string.Format("Name {0}, Type {1}", 
                 param.Name,
                 param.ParameterType.Name));
        }
    }
