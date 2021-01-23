    var constructor = ...;
    var parameters = constructor.GetParameters();
    object[] args = new object[parameters.Length];
    // Adjust this for private methods etc
    var buildMethod = typeof(ClassContainingBuild).GetMethod("Build");
    for (int i = 0; i < args.Length; i++)
    {
        var genericBuild = buildMethod.MakeGenericMethod(parameters[i].ParameterType);
        // Adjust appropropriately for target etc
        args[i] = genericBuild.Invoke(this, null); 
    }
