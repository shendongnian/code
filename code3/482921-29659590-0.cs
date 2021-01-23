    var currentAssembly = Assembly.GetExecutingAssembly();
    var callerAssemblies = new StackTrace().GetFrames()
            .Select(x => x.GetMethod().ReflectedType.Assembly).Distinct()
            .Where(x => x.GetReferencedAssemblies().Any(y => y.FullName ==     currentAssembly.FullName));
    var initialAssembly = callerAssemblies.Last();
